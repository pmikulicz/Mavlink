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

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents model of second version of mavlink packet
    /// </summary>
    internal sealed class PacketV2 : Packet
    {
        internal const byte HeaderValue = 0xFD;
        internal const int MaxPayloadSize = 253;

        /// <inheritdoc />
        public override byte Header => HeaderValue;

        /// <inheritdoc />
        public override int MessageId
        {
            get
            {
                Converter<int> converter = new Int32Converter();
                return converter.ConvertBytes(new[] { FirstByteOfId, MiddleByteOfId, LastByteOfId });
            }
        }

        /// <summary>
        /// Gest or sets flags that must be understood
        /// </summary>
        public byte IncompactFlags { get; set; }

        /// <summary>
        /// Gest or sets flags that can be ignored if not understood
        /// </summary>
        public byte CompactFlags { get; set; }

        /// <summary>
        /// Gets or sets first 8 bits of the id of the message
        /// </summary>
        public byte FirstByteOfId { get; set; }

        /// <summary>
        /// Gets or sets middle 8 bits of the id of the message
        /// </summary>
        public byte MiddleByteOfId { get; set; }

        /// <summary>
        /// Gets or sets last 8 bits of the id of the message
        /// </summary>
        public byte LastByteOfId { get; set; }

        /// <summary>
        /// Gets or sets optional field for point-to-point messages, used for payload else
        /// </summary>
        public byte TargetSystemId { get; set; }

        /// <summary>
        /// Gets or sets optional field for point-to-point messages, used for payload else
        /// </summary>
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