// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents model of first version of mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents model of first version of mavlink packet
    /// </summary>
    internal sealed class PacketV1 : Packet
    {
        internal const byte HeaderValue = 0xFE;
        internal const int MaxPayloadSize = 255;

        /// <inheritdoc />
        public override byte Header { get; } = HeaderValue;

        /// <inheritdoc />
        public override int MessageId => ByteId;

        /// <summary>
        /// Gets or sets id of message in payload as a byte
        /// </summary>
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