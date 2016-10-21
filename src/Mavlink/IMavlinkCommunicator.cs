// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkCommunicator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which is responsible for communication via mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using Mavlink.Messages.Definitions;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mavlink
{
    /// <summary>
    /// Interface of component which is responsible for communication via mavlink protocol
    /// </summary>
    public interface IMavlinkCommunicator<TMessage> : IDisposable where TMessage : ICommonMessage
    {
        /// <summary>
        /// Subscribes for notification of received message from mavlink protocol
        /// </summary>
        /// <param name="condition">A condition which must meet the message</param>
        /// <returns>Component which will notify an incoming message</returns>
        IMessageNotifier<TMessage> SubscribeForReceive(Func<TMessage, bool> condition);

        /// <summary>
        /// Sends message via mavlink protocol
        /// </summary>
        /// <param name="message">Message to be sent</param>
        /// <param name="systemId">Id of a system which is sending message</param>
        /// <param name="componentId">Id of a component which is sending message</param>
        /// <param name="sequenceNumber"></param>
        /// <returns>Value which indicates whether operation completed successfully</returns>
        bool SendMessage(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1);

        /// <summary>
        /// Sends message via mavlink protocol asynchronously
        /// </summary>
        /// <param name="message">Message to be sent</param>
        /// <param name="systemId">Id of a system which is sending message</param>
        /// <param name="componentId">Id of a component which is sending message</param>
        /// <param name="sequenceNumber"></param>
        /// <returns>Value which indicates whether operation completed successfully</returns>
        Task<bool> SendMessageAsync(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1);
    }
}