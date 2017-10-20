// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV2.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents model of second version of mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Represents model of second version of mavlink packet
    /// </summary>
    internal sealed class PacketV2 : Packet
    {
        /// <inheritdoc />
        public override byte Header { get; }

        /// <inheritdoc />
        public override byte[] RawBytes { get; }
    }
}