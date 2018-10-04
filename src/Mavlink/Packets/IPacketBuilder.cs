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
        /// <param name="packetBytes">
        /// Packet bytes from which packet will be built
        /// </param>
        /// <returns>
        /// New mavlink packet. If packet is not valid it returns null
        /// </returns>
        Packet Build(byte[] packetBytes);

        /// <summary>
        /// Gets mavlink version for which builder is dedicated
        /// </summary>
        MavlinkVersion MavlinkVersion { get; }
    }
}