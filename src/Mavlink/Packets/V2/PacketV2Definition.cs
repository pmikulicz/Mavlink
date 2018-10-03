// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1Definition.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents packet definition for second version of mavlink
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets.V2
{
    /// <summary>
    /// Represents packet definition for second version of mavlink
    /// </summary>
    internal sealed class PacketV2Definition : PacketDefinition
    {
        /// <inheritdoc />
        public override byte Header { get; } = 0xFD;

        /// <inheritdoc />
        public override int MaxPayloadLength { get; } = 253;

        /// <inheritdoc />
        public override int SignatureLength { get; } = 13;

        /// <inheritdoc />
        public override MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V20;
    }
}