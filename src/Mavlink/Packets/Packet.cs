// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Packet.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents abstract model of mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents abstract model of mavlink packet
    /// </summary>
    internal abstract class Packet
    {
        protected const int HeaderIndex = 0;

        /// <summary>
        /// Gets start of frame transmission
        /// </summary>
        public abstract byte Header { get; }

        /// <summary>
        /// Gets or sets identification of the message.
        /// The id defines what the payload "means" and how it should be correctly decoded
        /// </summary>
        public abstract int MessageId { get; }

        /// <summary>
        /// Gets or sets length of payload
        /// </summary>
        public byte PayloadLength { get; set; }

        /// <summary>
        /// Gets or sets sequence number. Each component counts up its send sequence.
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
        public byte[] RawBytes => GetBytes();

        /// <summary>
        /// Gets all packet bytes in the right order
        /// </summary>
        /// <returns></returns>
        protected abstract byte[] GetBytes();
    }
}