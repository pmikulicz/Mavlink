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
    internal interface IMessageFactory<TMessage> where TMessage : IMavlinkMessage
    {
        /// <summary>
        /// Creates mavlink message based on passed payload data and message id
        /// </summary>
        /// <param name="payload">Payload as an array of bytes  which message will be created from</param>
        /// <param name="messageId">Mavlink message id</param>
        /// <returns>Mavlink message</returns>
        TMessage CreateMessage(byte[] payload, int messageId);

        /// <summary>
        /// Creates array of bytes for packet payload based on passed mavlink message
        /// </summary>
        /// <typeparam name="TMessage">Mavlink message</typeparam>
        /// <param name="message">Mavlink message</param>
        /// <returns>Mavlink message as bytes array for packet payload</returns>
        byte[] CreateBytes(TMessage message);
    }
}