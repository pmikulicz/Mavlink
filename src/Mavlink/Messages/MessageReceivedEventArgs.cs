// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageReceivedEventArgs.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents event argument that is used to provide data for the MessageReceived event
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages
{
    /// <summary>
    /// Represents event argument that is used to provide data for the MessageReceived event
    /// </summary>
    public sealed class MessageReceivedEventArgs : EventArgs
    {
        public MessageReceivedEventArgs(IMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            Message = message;
        }

        /// <summary>
        /// Gets the message which was received from mavlink
        /// </summary>
        public IMessage Message { get; }
    }
}