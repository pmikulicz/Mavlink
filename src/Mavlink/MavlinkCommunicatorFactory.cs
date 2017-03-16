// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkCommunicatorFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for creating new instance of mavlink communicator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using Mavlink.Messages.Definitions;
using Mavlink.Packets;
using Mavlink.Connection;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for creating new instance of mavlink communicator
    /// </summary>
    public sealed class MavlinkCommunicatorFactory : IMavlinkCommunicatorFactory
    {
        /// <summary>
        /// Creates new instance of mavlink communicator
        /// </summary>
        /// <param name="connectionService"></param>
        /// <returns></returns>
        public IMavlinkCommunicator<TMessage> Create<TMessage>(IConnectionService connectionService) where TMessage : ICommonMessage
        {
            return new MavlinkCommunicator<TMessage>(connectionService, new PacketHandler(), new MessageFactory<TMessage>());
        }
    }
}