// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1Builder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for building single first version mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets.V1
{
    /// <summary>
    /// Component which is responsible for building the first version of the mavlink packet
    /// </summary>
    internal sealed class PacketV1Builder : IPacketBuilder
    {
        private readonly PacketStructure _packetStructure;

        public PacketV1Builder(PacketStructure packetStructure)
        {
            _packetStructure = packetStructure ?? throw new ArgumentNullException(nameof(packetStructure));
        }

        /// <inheritdoc />
        public Packet Build(byte[] packetBytes)
        {
            return null;
        }

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V10;
    }
}