// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Models;
using System;

namespace Mavlink.Messages
{
    internal sealed class MessageFactory : IMessageFactory
    {
        /// <summary>
        /// Creates mavlink message based on passed payload and message id
        /// </summary>
        /// <param name="payload">Payload from which message will be created</param>
        /// <param name="messageId">Id of created message</param>
        /// <returns>Mavlink message</returns>
        public Message Create(byte[] payload, int messageId)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            throw new System.NotImplementedException();
        }
    }
}