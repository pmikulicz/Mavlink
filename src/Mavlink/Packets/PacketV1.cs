// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents model of first version of mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Mavlink.Packets.Attributes;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents model of first version of mavlink packet
    /// </summary>
    [PacketInfo(CrcLength = 2, MavlinkVersion = MavlinkVersion.V10, MaxPayloadLength = 255, SignatureLength = 0)]
    internal sealed class PacketV1 : Packet
    {
        internal const byte HeaderValue = 0xFE;

        /// <inheritdoc />
        public override byte Header { get; protected set; } = HeaderValue;

        /// <inheritdoc />
        public override int MessageId => ByteId;

        /// <summary>
        /// Gets or sets id of message in payload as a byte
        /// </summary>
        [PacketData(Index = 5, MavlinkVersion = MavlinkVersion.V10)]
        public byte ByteId { get; set; }

        /// <inheritdoc />
        protected override byte[] GetBytes()
        {
            var rawBytes = new List<byte>
            {
                HeaderValue,
                PayloadLength,
                SequenceNumber,
                SystemId,
                ComponentId,
                (byte) MessageId
            };
            rawBytes.AddRange(Payload);
            rawBytes.AddRange(Checksum);

            return rawBytes.ToArray();
        }
    }
}