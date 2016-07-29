// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageNotifier.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for notifying about an incoming messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for notifying about an incoming messages
    /// </summary>
    internal sealed class MessageNotifier : IMessageNotifier
    {
        /// <summary>
        /// Occurs when a message is received from a mavlink
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
    }
}