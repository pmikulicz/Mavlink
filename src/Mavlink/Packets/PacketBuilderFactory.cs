// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketBuilderFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for creating instance of mavlink packet builder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Component which is responsible for creating instance of mavlink packet builder
    /// </summary>
    internal sealed class PacketBuilderFactory : IPacketBuilderFactory
    {
        private readonly MavlinkVersion _mavlinkVersion;

        public PacketBuilderFactory(MavlinkVersion mavlinkVersion)
        {
            _mavlinkVersion = mavlinkVersion;
        }

        /// <inheritdoc />
        public IPacketBuilder Create()
        {
            return new PacketBuilder();
        }
    }
}