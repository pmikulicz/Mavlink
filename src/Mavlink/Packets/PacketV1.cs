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
        internal const int PacketSequenceIndex = 2;
        internal const int SystemIdIndex = 3;
        internal const int ComponentIdIndex = 4;
        internal const int MessageIdIndex = 5;
        internal const int PayloadIndex = 6;
        internal const int ChecksumLength = 2;
        internal const int MetadataLength = 6;

        /// <summary>
        /// Gets start of frame transmission
        /// </summary>
        public override byte Header { get; } = HeaderValue;

        /// <summary>
        /// Gets packet array of raw bytes
        /// </summary>
        public override byte[] RawBytes
        {
            get
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
}