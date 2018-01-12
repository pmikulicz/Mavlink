﻿// --------------------------------------------------------------------------------------------------------------------
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
        private readonly List<byte> _packetBuffer = new List<byte>(50);

        public PacketBuilder(IPacketValidator packetValidator)
        {
            if (packetValidator == null)
                throw new ArgumentNullException(nameof(packetValidator));

            _packetValidator = packetValidator;
        }

        public PacketBuilder()
            : this(new PacketValidator())
        {
        }

        /// <inheritdoc />
        public bool AddByte(byte packetByte)
        {
            //            if (packetByte == Packet.HeaderValue)
            //                _packetBuffer.Clear();

            _packetBuffer.Add(packetByte);
            byte[] packetBytes = _packetBuffer.ToArray();

            return HasPacketMetadata(packetBytes) && IsPacketComplete(packetBytes);
        }

        /// <inheritdoc />
        public Packet Build(BuildType buildType = BuildType.WithCrc)
        {
            return null;
            //            byte[] packetBytes = _packetBuffer.ToArray();
            //            _packetBuffer.Clear();
            //
            //            if (!(HasPacketMetadata(packetBytes) && IsPacketComplete(packetBytes)))
            //                return null;
            //
            //            if (packetBytes[Packet.HeaderIndex] != Packet.HeaderValue)
            //                return null;
            //
            //            int payloadLength = Convert.ToInt32(packetBytes[Packet.PayloadLengthIndex]);
            //            byte[] payload = new byte[payloadLength];
            //            Array.Copy(packetBytes, Packet.PayloadIndex, payload, 0, payloadLength);
            //
            //            return ProcessBuildPacket(packetBytes, packetBytes[Packet.PayloadLengthIndex], payload, buildType);
        }

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion => MavlinkVersion.V10;

        private Packet ProcessBuildPacket(byte[] packetBytes, byte payloadLength, byte[] payload, BuildType buildType)
        {
            return null;
            //            byte[] checksum = new byte[Packet.ChecksumLength];
            //            Array.Copy(packetBytes, Packet.PayloadIndex + payloadLength, checksum, 0, Packet.ChecksumLength);
            //
            //            Packet packet = new Packet
            //            {
            //                PayloadLength = payloadLength,
            //                SequenceNumber = packetBytes[Packet.PacketSequenceIndex],
            //                SystemId = packetBytes[Packet.SystemIdIndex],
            //                ComponentId = packetBytes[Packet.ComponentIdIndex],
            //                MessageIdOld = (MessageIdOld)packetBytes[Packet.MessageIdIndex],
            //                Payload = payload,
            //                Checksum = checksum
            //            };
            //
            //            if (buildType == BuildType.WithoutCrc)
            //                packet.Checksum = _packetValidator.GetChecksum(packet);
            //
            //            if (buildType == BuildType.WithCrc)
            //                return _packetValidator.Validate(packet) ? packet : null;
            //
            //            return packet;
        }

        private static bool IsPacketComplete(byte[] bytes)
        {
            return true;
            //            int payloadLength = Convert.ToInt32(bytes[Packet.PayloadLengthIndex]);
            //            int totalPacketLength = Packet.MetadataLength + Packet.ChecksumLength + payloadLength;
            //
            //            return bytes.Length == totalPacketLength;
        }

        private static bool HasPacketMetadata(byte[] bytes)
        {
            return true;
            //            return bytes.Length > Packet.MetadataLength;
        }
    }
}