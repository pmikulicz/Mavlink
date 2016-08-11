// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Packet.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents model of single mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using System.Collections.Generic;

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents model of single mavlink packet
    /// </summary>
    internal sealed class Packet
    {
        internal const byte HeaderValue = 0xFE;
        internal const int HeaderIndex = 0;
        internal const int PayloadLengthIndex = 1;
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
        public byte Header { get; } = HeaderValue;

        /// <summary>
        /// Gets or sets length of payload
        /// </summary>
        public byte PayloadLength { get; set; }

        /// <summary>
        /// Gets or sets sequence number. Each component counts up his send sequence.
        /// Allows to detect packet loss
        /// </summary>
        public byte SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets identification of the sending system.
        /// Allows to differentiate different systems on the same network
        /// </summary>
        public byte SystemId { get; set; }

        /// <summary>
        /// Gets or sets identification of the sending component.
        /// Allows to differentiate different components of the same system,
        /// e.g. the IMU and the autopilot
        /// </summary>
        public byte ComponentId { get; set; }

        /// <summary>
        /// Gets or sets identification of the message.
        /// The id defines what the payload "means" and how it should be correctly decoded
        /// </summary>
        public MessageId MessageId { get; set; }

        /// <summary>
        /// Gets or sets the data of the message, depends on the message id
        /// </summary>
        public byte[] Payload { get; set; }

        /// <summary>
        /// Gets or sets checksum of the entire packet, excluding the packet start sign
        /// </summary>
        public byte[] Checksum { get; set; }

        /// <summary>
        /// Gets packet array of raw bytes
        /// </summary>
        public byte[] RawBytes
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