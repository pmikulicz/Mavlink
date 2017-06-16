// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageNotifier.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for notifying about an incoming messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System;

namespace Mavlink.Messages
{
    /// <summary>
    /// Component which is responsible for notifying about an incoming messages
    /// </summary>
    internal sealed class MessageNotifier<TMessage> : IMessageNotifier<TMessage> where TMessage : ICommonMessage
    {
        /// <inheritdoc />
        public event EventHandler<MessageReceivedEventArgs<TMessage>> MessageReceived;

        /// <summary>
        /// Invokes MessageReceived event
        /// </summary>
        /// <param name="args"></param>
        internal void OnMessageReceived(MessageReceivedEventArgs<TMessage> args)
        {
            MessageReceived?.Invoke(this, args);
        }
    }
}