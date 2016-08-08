// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessage.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Common interface of all mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages
{
    /// <summary>
    /// Common interface of all mavlink messages
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        MessageId Id { get; }
    }
}