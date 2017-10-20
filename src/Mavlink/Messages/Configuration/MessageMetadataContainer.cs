// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMetadataContainer.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Container for message metadata of particulat mavlink dialect
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Container for message metadata of particulat mavlink dialect
    /// </summary>
    internal sealed class MessageMetadataContainer : IMessageMetadataContainer
    {
        private readonly IDictionary<int, MessageMetadata> _messageMetadataById;

        public MessageMetadataContainer(IEnumerable<MessageMetadata> messageMetadata)
        {
            var messageMetadataArray = messageMetadata as MessageMetadata[] ?? messageMetadata.ToArray();
            _messageMetadataById = messageMetadataArray.ToDictionary(metadata => metadata.Id);
            Quantity = messageMetadataArray.Length;
        }

        /// <inheritdoc />
        public MessageMetadata Get(int messageId)
        {
            return _messageMetadataById.TryGetValue(messageId, out var messageMetadata) ? messageMetadata : null;
        }

        /// <inheritdoc />
        public int Quantity { get; }
    }
}