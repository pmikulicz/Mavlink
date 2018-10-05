// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketBuilderFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for creating new instance of packet builder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    ///  Interface of a component which is responsible for creating new instance of packet builder
    /// </summary>
    internal interface IPacketBuilderFactory
    {
        /// <summary>
        /// Creates new instance of packet builder
        /// </summary>
        /// <param name="packetBytes">Packet bytes from chich packet will be created</param>
        /// <param name="packetStructure">Definition of packet structure</param>
        /// <returns>New instance of packet builder</returns>
        IPacketBuilder Create(byte[] packetBytes, PacketStructure packetStructure);

        /// <summary>
        /// Gest mavlink version for which factory is dedicated
        /// </summary>
        MavlinkVersion MavlinkVersion { get; }
    }
}