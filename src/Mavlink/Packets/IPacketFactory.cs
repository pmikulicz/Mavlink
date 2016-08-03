// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which is responsible for creating a packet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of component which is responsible for creating a mavlink packet
    /// </summary>
    internal interface IPacketFactory
    {
        /// <summary>
        /// Creates a mavlink packet based on bytes array
        /// </summary>
        /// <param name="bytes">Bytes array on which packet will be created</param>
        /// <returns>New mavlink packet</returns>
        Packet Create(byte[] bytes);
    }
}