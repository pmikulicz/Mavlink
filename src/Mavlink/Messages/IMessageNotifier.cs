// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageNotifier.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for notifying about an incoming mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages
{
    /// <summary>
    /// Interface of a component which is responsible for notifying about an incoming mavlinkmessages
    /// </summary>
    public interface IMessageNotifier<TMessage> where TMessage : MavlinkMessage
    {
        /// <summary>
        /// Occurs when a message is received from a mavlink
        /// </summary>
        event EventHandler<MessageReceivedEventArgs<TMessage>> MessageReceived;
    }
}