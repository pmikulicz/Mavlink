// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkCommunicator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which is responsible for communication via mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using System;

namespace Mavlink
{
    /// <summary>
    /// Interface of component which is responsible for communication via mavlink protocol
    /// </summary>
    public interface IMavlinkCommunicator : IDisposable
    {
        /// <summary>
        /// Subscribes for notification of received message from mavlink protocol
        /// </summary>
        /// <param name="condition">A condition which must meet the message</param>
        /// <returns>Component which will notify an incoming message</returns>
        IMessageNotifier SubscribeForReceive(Func<IMessage, bool> condition);

        /// <summary>
        /// Sends message via mavlink protocol asynchronously
        /// </summary>
        /// <param name="message">Message to be sent</param>
        /// <param name="systemId">Id of a system which is sending message</param>
        /// <param name="componentId">Id of a component which is sending message</param>
        /// <returns>Value which indicates whether operation completed successfully</returns>
        bool SendMessage<TMessage>(TMessage message, byte systemId, byte componentId)
            where TMessage : struct, IMessage;
    }
}