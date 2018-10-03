// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1Definition.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents packet definition for first version of mavlink
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets.V1
{
    /// <summary>
    ///  Represents packet definition for first version of mavlink
    /// </summary>
    internal sealed class PacketV1Definition : PacketDefinition
    {
        /// <inheritdoc />
        public override byte Header { get; } = 0xFE;

        /// <inheritdoc />
        public override int MaxPayloadLength { get; } = 255;

        /// <inheritdoc />
        public override int SignatureLength { get; } = 0;

        /// <inheritdoc />
        public override MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V10;
    }
}