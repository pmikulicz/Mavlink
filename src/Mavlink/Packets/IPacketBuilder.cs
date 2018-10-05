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
        /// <returns>
        /// New mavlink packet. If packet is not valid it returns null
        /// </returns>
        Packet Build();
    }
}