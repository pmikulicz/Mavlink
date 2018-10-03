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
        /// <summary>
        /// Gets incompact flags position in packet
        /// </summary>
        public byte IncompactFlagsIndex { get; } = 2;

        /// <summary>
        /// Gets compact flags position in packet
        /// </summary>
        public byte CompactFlagsIndex { get; } = 3;

        /// <inheritdoc />
        public override byte SequenceNumberIndex { get; } = 4;

        /// <inheritdoc />
        public override byte SystemIdIndex { get; } = 5;

        /// <inheritdoc />
        public override byte ComponentIdIndex { get; } = 6;

        /// <summary>
        ///  Gets first byte of id position in packet
        /// </summary>
        public byte FirstByteOfIdIndex { get; } = 7;

        /// <summary>
        /// Gets middle byte of id position in packet
        /// </summary>
        public byte MiddleByteOfIdIndex { get; } = 8;

        /// <summary>
        /// Gets last byte of id position in packet
        /// </summary>
        public byte LastByteOfIdIndex { get; } = 9;

        /// <summary>
        /// Gets target system id position in packet
        /// </summary>
        public byte TargetSystemIdIdIndex { get; } = 10;

        /// <summary>
        /// /// <summary>
        /// Gets target component id position in packet
        /// </summary>
        /// </summary>
        public byte TargetComponentIdIndex { get; } = 11;

        /// <inheritdoc />
        public override MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V20;
    }
}