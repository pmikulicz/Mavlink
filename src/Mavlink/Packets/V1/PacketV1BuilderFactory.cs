// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketV1BuilderFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents component which is responsible for creating new instance of packet builder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets.V1
{
    /// <summary>
    /// Represents component which is responsible for creating new instance of packet builder
    /// </summary>
    internal class PacketV1BuilderFactory : IPacketBuilderFactory
    {
        /// <inheritdoc />
        public IPacketBuilder Create(byte[] packetBytes, PacketStructure packetStructure)
        {
            if (packetBytes == null) throw new ArgumentNullException(nameof(packetBytes));
            if (packetStructure == null) throw new ArgumentNullException(nameof(packetStructure));

            return new PacketV1Builder(packetBytes, packetStructure);
        }

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion { get; } = MavlinkVersion.V10;
    }
}