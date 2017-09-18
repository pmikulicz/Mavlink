// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageMetadataContainer.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a container for message metadata
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    ///  Interface of a container for message metadata
    /// </summary>
    internal interface IMessageMetadataContainer
    {
        /// <summary>
        /// Gets message metadata based on the message type
        /// </summary>
        /// <param name="messageType">Message type</param>
        /// <returns>Metadata of mavlink message</returns>
        MessageMetadata Get(Type messageType);

        /// <summary>
        /// Gets quantity of message metadata
        /// </summary>
        /// <returns></returns>
        int Quantity { get; }
    }
}