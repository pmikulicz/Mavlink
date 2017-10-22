// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageMetadataContainer.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a container for message metadata of particulat mavlink dialect
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    ///  Interface of a container for message metadata of particulat mavlink dialect
    /// </summary>
    internal interface IMessageMetadataContainer
    {
        /// <summary>
        /// Gets message metadata based on its id
        /// </summary>
        /// <param name="messageId">Message id of particulat mavlink dialect</param>
        /// <returns>Metadata of mavlink message</returns>
        MessageMetadata Get(int messageId);

        /// <summary>
        /// Gets quantity of message metadata of particulat mavlink dialect
        /// </summary>
        /// <returns></returns>
        int Quantity { get; }
    }
}