// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkCommunicatorFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which is responsible for creating new instance of mavlink communicator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Connection;
using Mavlink.Messages;

namespace Mavlink
{
    /// <summary>
    /// Interface of component which is responsible for creating new instance of mavlink communicator
    /// </summary>
    public interface IMavlinkCommunicatorFactory
    {
        /// <summary>
        /// Creates new instance of mavlink communicator
        /// </summary>
        /// <param name="connectionService">Instance of connection service</param>
        /// <param name="mavlinkVersion">Mavlink version to be used for communication</param>
        /// <returns>New instance of mavlin communicator</returns>
        IMavlinkCommunicator<TMessage> Create<TMessage>(IConnectionService connectionService, MavlinkVersion mavlinkVersion)
            where TMessage : IMavlinkMessage;
    }
}