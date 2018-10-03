// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Abstract model of packet definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Abstract model of packet definition
    /// </summary>
    internal abstract class PacketDefinition
    {
        /// <summary>
        /// Gets packet header value
        /// </summary>
        public abstract byte Header { get; }

        /// <summary>
        /// Gets cyclic redundancy check length
        /// </summary>
        public int CrCLength { get; } = 2;

        /// <summary>
        /// Gets max payload length
        /// </summary>
        public abstract int MaxPayloadLength { get; }

        /// <summary>
        /// Gets signature length
        /// </summary>
        public abstract int SignatureLength { get; }

        /// <summary>
        /// Gets mavlink version of metadata
        /// </summary>
        public abstract MavlinkVersion MavlinkVersion { get; }
    }
}