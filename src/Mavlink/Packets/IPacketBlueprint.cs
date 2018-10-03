// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Interface of a component which gives blueprint of packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which gives blueprint of packet
    /// </summary>
    internal interface IPacketBlueprint
    {
        /// <summary>
        /// Gets packet definition
        /// </summary>
        /// <param name="mavlinkVersion">Mavlink version of packet</param>
        /// <returns>Packet definition for specific mavlink version</returns>
        PacketDefinition GetPacketDefinition(MavlinkVersion mavlinkVersion);

        /// <summary>
        /// Gets packet structure
        /// </summary>
        /// <param name="mavlinkVersion">Mavlink version of packet</param>
        /// <returns>Packet structure for specific mavlink version</returns>
        PacketStructure GetPacketStructrure(MavlinkVersion mavlinkVersion);
    }
}