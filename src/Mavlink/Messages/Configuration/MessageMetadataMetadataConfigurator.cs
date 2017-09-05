// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which allows to configure mavlink message metadata
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages.Configuration
{
    /// <inheritdoc />
    internal sealed class MessageMetadataMetadataConfigurator : IMessageMetadataConfigurator
    {
        private readonly MessageMetadata _messageMetadata;

        public MessageMetadataMetadataConfigurator(MessageMetadata messageMetadata)
        {
            _messageMetadata = messageMetadata ?? throw new ArgumentNullException(nameof(messageMetadata));
        }

        /// <inheritdoc />
        public IMessageMetadataConfigurator SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _messageMetadata.Name = name;

            return this;
        }

        /// <inheritdoc />
        public IMessageMetadataConfigurator SetId(int id)
        {
            _messageMetadata.Id = id;

            return this;
        }
    }
}