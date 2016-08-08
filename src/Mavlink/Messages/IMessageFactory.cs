// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Interface of a component which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages
{
    /// <summary>
    /// Interface of a component which is responsible for creating mavlink messages
    /// </summary>
    internal interface IMessageFactory
    {
        /// <summary>
        /// Creates mavlink message based on passed payload and message id
        /// </summary>
        /// <param name="payload">Payload from which message will be created</param>
        /// <param name="messageId">Id of created message</param>
        /// <returns>Mavlink message</returns>
        IMessage Create(byte[] payload, MessageId messageId);
    }
}