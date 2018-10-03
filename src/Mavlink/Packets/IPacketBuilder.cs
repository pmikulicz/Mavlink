// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketBuilder.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for building single mavlink packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which is responsible for building single mavlink packet
    /// </summary>
    internal interface IPacketBuilder
    {
        /// <summary>
        /// Builds mavlink packet
        /// </summary>
        /// <param name="buildType">
        /// Type of a build.
        /// Builder can build packet with crc or without crc
        /// </param>
        /// <returns>
        /// New mavlink packet. If packet is not valid it returns null
        /// </returns>
        Packet Build(BuildType buildType = BuildType.WithCrc);

        /// <summary>
        /// Gets mavlink version for which builder is dedicated
        /// </summary>
        MavlinkVersion MavlinkVersion { get; }
    }
}