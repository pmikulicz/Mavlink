// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1Builder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for building single first version mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    /// Component which is responsible for building single first version mavlink packet
    /// </summary>
    internal sealed class PacketV1Builder : IPacketBuilder
    {
        private readonly IPacketValidator _packetValidator;

        public PacketV1Builder(IPacketValidator packetValidator)
        {
            _packetValidator = packetValidator ?? throw new ArgumentNullException(nameof(packetValidator));
        }

        public PacketV1Builder()
            : this(new PacketValidator())
        {
        }

        /// <inheritdoc />
        public bool AddByte(byte packetByte)
        {
            return true;
            //            if (packetByte == PacketV1.HeaderValue)
            //                _packetBuffer.Clear();
            //
            //            _packetBuffer.Add(packetByte);
            //
            //            return HasPacketMetadata(_packetBuffer) & IsPacketComplete(_packetBuffer);
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
            //            if (packetBytes[Packet.HeaderIndex] != PacketV1.HeaderValue)
            //                return null;
            //
            //            int payloadLength = packetBytes[Packet.PayloadLengthIndex];
            //            byte[] payload = new byte[payloadLength];
            //            Array.Copy(packetBytes, PacketV1.PayloadIndex, payload, 0, payloadLength);
            //
            //            return ProcessBuildPacket(packetBytes, packetBytes[Packet.PayloadLengthIndex], payload, buildType);
        }

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion => MavlinkVersion.V10;

        private Packet ProcessBuildPacket(byte[] packetBytes, byte payloadLength, byte[] payload, BuildType buildType)
        {
            return null;

            //            byte[] checksum = new byte[Packet.ChecksumLength];
            //            Array.Copy(packetBytes, PacketV1.PayloadIndex + payloadLength, checksum, 0, Packet.ChecksumLength);
            //
            //            PacketV1 packet = new PacketV1()
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

        private static bool IsPacketComplete(IReadOnlyList<byte> bytes)
        {
            return true;
            //            int payloadLength = bytes[Packet.PayloadLengthIndex];
            //            int totalPacketLength = PacketV1.MetadataLength + Packet.ChecksumLength + payloadLength;
            //
            //            return bytes.Count == totalPacketLength;
        }

        private static bool HasPacketMetadata(ICollection bytes)
        {
            return true;
        }
    }
}