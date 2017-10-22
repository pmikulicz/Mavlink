// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMetadataContainer.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Container for message metadata
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Container for message metadata
    /// </summary>
    internal sealed class MessageMetadataContainer : IMessageMetadataContainer
    {
        private readonly IDictionary<Type, MessageMetadata> _messageMetadataByType;

        public MessageMetadataContainer(IEnumerable<MessageMetadata> messageMetadata)
        {
            var messageMetadataArray = messageMetadata as MessageMetadata[] ?? messageMetadata.ToArray();
            _messageMetadataByType = messageMetadataArray.ToDictionary(metadata => metadata.Type);
            Quantity = messageMetadataArray.Length;
        }

        /// <inheritdoc />
        public MessageMetadata Get(Type messageType)
        {
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));

            return _messageMetadataByType.TryGetValue(messageType, out var messageMetadata) ? messageMetadata : null;
        }


        /// <inheritdoc />
        public int Quantity { get; }
    }
}