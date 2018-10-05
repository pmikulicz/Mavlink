// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Packet.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents internal structure of first version of packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets.V1
{
    /// <summary>
    /// Represents internal structure of first version of packet
    /// </summary>
    internal sealed class PacketV1Structure : PacketStructure
    {
        /// <inheritdoc />
        public override byte Header { get; } = 0xFE;

        /// <inheritdoc />
        public override byte SequenceNumberIndex { get; } = 2;

        /// <inheritdoc />
        public override byte SystemIdIndex { get; } = 3;

        /// <inheritdoc />
        public override byte ComponentIdIndex { get; } = 4;

        /// <summary>
        /// Gets message id position in packet
        /// </summary>
        public int MessageIdIndex { get; } = 5;

        /// <inheritdoc />
        public override MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V10;
    }
}