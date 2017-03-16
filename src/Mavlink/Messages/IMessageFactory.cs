// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Interface of a component which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;
using Mavlink.Messages.Definitions;

[assembly: InternalsVisibleTo("Mavlink.UnitTests")]

namespace Mavlink.Messages
{
    /// <summary>
    /// Interface of a component which is responsible for creating mavlink messages
    /// </summary>
    internal interface IMessageFactory<TMessage> where TMessage : ICommonMessage
    {
        /// <summary>
        /// Creates mavlink message based on passed payload and message id
        /// </summary>
        /// <param name="payload">Payload from which message will be created</param>
        /// <param name="messageId">Id of created message</param>
        /// <returns>Mavlink message</returns>
        TMessage CreateMessage(byte[] payload, MessageId messageId);

        /// <summary>
        /// Creates array of bytes based on passed mavlink message
        /// </summary>
        /// <typeparam name="TMessage">Mavlink message</typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        byte[] CreateBytes(TMessage message);
    }
}