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
        private readonly byte[] _packetBytes;

        public PacketV1Builder(byte[] packetBytes, PacketStructure packetStructure)
        {
            _packetBytes = packetBytes ?? throw new ArgumentNullException(nameof(packetBytes));
            _packetStructure = packetStructure ?? throw new ArgumentNullException(nameof(packetStructure));
        }

        /// <inheritdoc />
        public Packet Build()
        {
            return null;
        }

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V10;
    }
}