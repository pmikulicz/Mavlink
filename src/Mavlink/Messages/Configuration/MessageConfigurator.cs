// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which allows to configure message details
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages.Configuration
{
    /// <inheritdoc />
    internal sealed class MessageConfigurator : IMessageConfigurator
    {
        private readonly MessageDetails _messageDetails;

        public MessageConfigurator(MessageDetails messageDetails)
        {
            _messageDetails = messageDetails ?? throw new ArgumentNullException(nameof(messageDetails));
        }

        /// <inheritdoc />
        public IMessageConfigurator SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _messageDetails.Name = name;

            return this;
        }

        /// <inheritdoc />
        public IMessageConfigurator SetId(int id)
        {
            _messageDetails.Id = id;

            return this;
        }
    }
}