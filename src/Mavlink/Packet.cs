﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Packet.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents model of single mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink
{
    /// <summary>
    /// Represents model of single mavlink packet
    /// </summary>
    internal sealed class Packet
    {
        public Packet(byte payloadLength, byte sequenceNumber, byte systemId, byte componentId, byte messageId, byte[] payload, byte checksum)
        {
            Header = HeaderValue;
            PayloadLength = payloadLength;
            SequenceNumber = sequenceNumber;
            SystemId = systemId;
            ComponentId = componentId;
            MessageId = messageId;
            Payload = payload;
            Checksum = checksum;
        }

        /// <summary>
        /// Gets start of frame transmission
        /// </summary>
        public byte Header { get; }

        /// <summary>
        /// Gets length of payload
        /// </summary>
        public byte PayloadLength { get; }

        /// <summary>
        /// Gets sequence number. Each component counts up his send sequence.
        /// Allows to detect packet loss
        /// </summary>
        public byte SequenceNumber { get; }

        /// <summary>
        /// Gets identification of the sending system.
        /// Allows to differentiate different systems on the same network
        /// </summary>
        public byte SystemId { get; }

        /// <summary>
        /// Gets identification of the sending component.
        /// Allows to differentiate different components of the same system,
        /// e.g. the IMU and the autopilot
        /// </summary>
        public byte ComponentId { get; }

        /// <summary>
        /// Gets identification of the message.
        /// The id defines what the payload "means" and how it should be correctly decoded
        /// </summary>
        public byte MessageId { get; }

        /// <summary>
        /// Gets the data of the message, depends on the message id
        /// </summary>
        public byte[] Payload { get; }

        /// <summary>
        /// Gets checksum of the entire packet, excluding the packet start sign
        /// </summary>
        public byte Checksum { get; }

        internal static byte HeaderValue = 0xFE;
    }
}