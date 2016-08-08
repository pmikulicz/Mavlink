// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketBuilder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for building single mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    /// Component which is responsible for building single mavlink packet
    /// </summary>
    internal sealed class PacketBuilder : IPacketBuilder
    {
        private readonly IPacketValidator _packetValidator;
        private readonly List<byte> _packetBuffer = new List<byte>(20);

        public PacketBuilder(IPacketValidator packetValidator)
        {
            if (packetValidator == null)
                throw new ArgumentNullException(nameof(packetValidator));

            _packetValidator = packetValidator;
        }

        public PacketBuilder()
            : this(null)
        {
        }

        /// <summary>
        /// Add single packet byte
        /// </summary>
        /// <param name="packetByte">Single packet byte</param>
        /// <returns>value indicating whether all packet bytes were collected and are ready to build</returns>
        public bool AddByte(byte packetByte)
        {
            if (packetByte == Packet.HeaderValue)
                _packetBuffer.Clear();

            _packetBuffer.Add(packetByte);

            return HasPacketMetadata(_packetBuffer.ToArray()) &&
                IsPacketComplete(_packetBuffer.ToArray());
        }

        /// <summary>
        /// Builds mavlink packet from aggregated bytes
        /// </summary>
        /// <returns>
        /// New packet from aggregated bytes.
        /// If packet is not valid it returns null
        /// </returns>
        public Packet Build()
        {
            byte[] packetBytes = _packetBuffer.ToArray();
            _packetBuffer.Clear();

            if (!(HasPacketMetadata(packetBytes) && IsPacketComplete(packetBytes)))
                return null;

            if (packetBytes[Packet.HeaderIndex] != Packet.HeaderValue)
                return null;

            byte[] checksum = new byte[Packet.ChecksumLength];
            int payloadLength = Convert.ToInt32(packetBytes[Packet.PayloadLengthIndex]);
            byte[] payload = new byte[payloadLength];
            Array.Copy(packetBytes, Packet.PayloadIndex + payloadLength, checksum, 0, Packet.ChecksumLength);
            Array.Copy(packetBytes, Packet.PayloadIndex, payload, 0, payloadLength);

            Packet packet = new Packet(packetBytes[Packet.PayloadLengthIndex], packetBytes[Packet.PacketSequenceIndex], packetBytes[Packet.SystemIdIndex],
                packetBytes[Packet.ComponentIdIndex], packetBytes[Packet.MessageIdIndex], payload, checksum);

            return _packetValidator.Validate(packet) ? packet : null;
        }

        private static bool IsPacketComplete(byte[] bytes)
        {
            int payloadLength = Convert.ToInt32(bytes[Packet.PayloadLengthIndex]);
            int totalPacketLength = Packet.MetadataLength + Packet.ChecksumLength + payloadLength;

            return bytes.Length == totalPacketLength;
        }

        private static bool HasPacketMetadata(byte[] bytes)
        {
            return bytes.Length > Packet.MetadataLength;
        }
    }
}