// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPacketBuilderFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//  Interface of a component which is responsible for creating instance of mavlink packet builder
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which is responsible for creating instance of mavlink packet builder
    /// </summary>
    internal interface IPacketBuilderFactory
    {
        /// <summary>
        /// Creates instance of mavlink packet builder
        /// </summary>
        /// <returns></returns>
        IPacketBuilder Create();
    }
}