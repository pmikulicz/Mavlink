// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkCommunicatorFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which is responsible for creating new instance of mavlink communicator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using Mavlink.Connection;

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
        /// <param name="connectionService"></param>
        /// <returns></returns>
        IMavlinkCommunicator<TMessage> Create<TMessage>(IConnectionService connectionService)
            where TMessage : ICommonMessage;
    }
}