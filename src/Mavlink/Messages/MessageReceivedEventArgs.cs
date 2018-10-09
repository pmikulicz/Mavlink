// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageReceivedEventArgs.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents event argument that is used to provide data for the MessageReceived event
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages
{
    /// <summary>
    /// Represents event argument that is used to provide data for the MessageReceived event
    /// </summary>
    public sealed class MessageReceivedEventArgs<TMessage> : System.EventArgs where TMessage : IMavlinkMessage
    {
        public MessageReceivedEventArgs(TMessage message, int componentId, int systemId)
        {
            Message = message;
        }

        /// <summary>
        /// Gets the message which was received from mavlink
        /// </summary>
        public TMessage Message { get; }

        /// <summary>
        /// Gets the id of the component from which the message was sent
        /// </summary>
        public int ComponentId { get; set; }

        /// <summary>
        /// Gets the id of the system from which the message was sent
        /// </summary>
        public int SystemId { get; set; }
    }
}