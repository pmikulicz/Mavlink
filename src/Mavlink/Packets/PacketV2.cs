// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV2.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents model of second version of mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common.Converters;
using System.Collections.Generic;
using Mavlink.Packets.Attributes;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents model of second version of mavlink packet
    /// </summary>
    [PacketInfo(CrcLength = 2, MavlinkVersion = MavlinkVersion.V20, MaxPayloadLength = 253, SignatureLength = 13)]
    internal sealed class PacketV2 : Packet
    {
        internal const byte HeaderValue = 0xFD;

        public override byte Header { get; protected set; } = HeaderValue;

        /// <inheritdoc />
        public override int MessageId
        {
            get
            {
                Converter<int> converter = new Int32Converter();
                return converter.ConvertBytes(new[] { FirstByteOfId, MiddleByteOfId, LastByteOfId, (byte)0 });
            }
        }

        /// <summary>
        /// Gest or sets flags that must be understood
        /// </summary>
        [PacketData(Index = 2, MavlinkVersion = MavlinkVersion.V20)]
        public byte IncompactFlags { get; set; }

        /// <summary>
        /// Gest or sets flags that can be ignored if not understood
        /// </summary>
        [PacketData(Index = 3, MavlinkVersion = MavlinkVersion.V20)]
        public byte CompactFlags { get; set; }

        /// <summary>
        /// Gets or sets first 8 bits of the id of the message
        /// </summary>
        [PacketData(Index = 7, MavlinkVersion = MavlinkVersion.V20)]
        public byte FirstByteOfId { get; set; }

        /// <summary>
        /// Gets or sets middle 8 bits of the id of the message
        /// </summary>
        [PacketData(Index = 8, MavlinkVersion = MavlinkVersion.V20)]
        public byte MiddleByteOfId { get; set; }

        /// <summary>
        /// Gets or sets last 8 bits of the id of the message
        /// </summary>
        [PacketData(Index = 9, MavlinkVersion = MavlinkVersion.V20)]
        public byte LastByteOfId { get; set; }

        /// <summary>
        /// Gets or sets optional field for point-to-point messages, used for payload else
        /// </summary>
        [PacketData(Index = 10, MavlinkVersion = MavlinkVersion.V20)]
        public byte TargetSystemId { get; set; }

        /// <summary>
        /// Gets or sets optional field for point-to-point messages, used for payload else
        /// </summary>
        [PacketData(Index = 11, MavlinkVersion = MavlinkVersion.V20)]
        public byte TargetComponentId { get; set; }

        /// <summary>
        /// Gets or sets signature which allows ensuring that the link is tamper-proof
        /// </summary>
        public byte[] Signature { get; set; }

        /// <inheritdoc />
        protected override byte[] GetBytes()
        {
            var rawBytes = new List<byte>
            {
                HeaderValue,
                PayloadLength,
                IncompactFlags,
                CompactFlags,
                SequenceNumber,
                SystemId,
                ComponentId,
                FirstByteOfId,
                MiddleByteOfId,
                LastByteOfId,
                TargetSystemId,
                TargetComponentId
            };
            rawBytes.AddRange(Payload);
            rawBytes.AddRange(Checksum);
            rawBytes.AddRange(Signature);

            return rawBytes.ToArray();
        }
    }
}