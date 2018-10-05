// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents internal structure of second version of packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets.V2
{
    /// <summary>
    /// Represents internal structure of second version of packet
    /// </summary>
    internal sealed class PacketV2Structure : PacketStructure
    {
        /// <inheritdoc />
        public override byte Header { get; } = 0xFD;

        /// <summary>
        /// Gets incompact flags position in packet
        /// </summary>
        public byte IncompactFlagsIndex { get; } = 2;

        /// <summary>
        /// Gets compact flags position in packet
        /// </summary>
        public byte CompactFlagsIndex { get; } = 3;

        /// <inheritdoc />
        public override int SequenceNumberIndex { get; } = 4;

        /// <inheritdoc />
        public override int SystemIdIndex { get; } = 5;

        /// <inheritdoc />
        public override int ComponentIdIndex { get; } = 6;

        /// <summary>
        ///  Gets first byte of id position in packet
        /// </summary>
        public int FirstByteOfIdIndex { get; } = 7;

        /// <summary>
        /// Gets middle byte of id position in packet
        /// </summary>
        public int MiddleByteOfIdIndex { get; } = 8;

        /// <summary>
        /// Gets last byte of id position in packet
        /// </summary>
        public int LastByteOfIdIndex { get; } = 9;

        /// <inheritdoc />
        public override int PayloadIndex { get; } = 10;

        /// <inheritdoc />
        public override MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V20;
    }
}