// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBuildEventsConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which allows to configure build events
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Packets
{
    /// <summary>
    /// Interface of a component which allows to configure build events
    /// </summary>
    internal interface IBuildEventsConfigurator
    {
        /// <summary>
        /// Sets action which is performed on successfully created packet
        /// </summary>
        /// <param name="packetCreated">Action which is performed on successfully created packet</param>
        /// <returns></returns>
        IBuildEventsConfigurator SetPacketCreated(Action<Packet> packetCreated);

        /// <summary>
        /// Sets action which is performed on unsuccessfully created packet
        /// </summary>
        /// <param name="invalidPacketCreated">Action which is performed on unsuccessfully created packet</param>
        /// <returns></returns>
        IBuildEventsConfigurator SetPacketCreated(Action<byte[]> invalidPacketCreated);
    }
}