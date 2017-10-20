// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common.Converters;
using Mavlink.Messages.Configuration;
using System;
using System.Reflection;

namespace Mavlink.Messages
{
    /// <summary>
    /// Factory which is responsible for creating mavlink messages
    /// </summary>
    internal sealed class MessageFactory<TMessage> : IMessageFactory<TMessage> where TMessage : MavlinkMessage
    {
        private readonly IMessageMetadataContainer _messageMetadataContainer;
        private readonly IByteConverterSelector _byteConverterSelector;

        public MessageFactory(IMessageMetadataContainerFactory messageMetadataContainerFactory, IByteConverterSelector byteConverterSelector)
        {
            if (messageMetadataContainerFactory == null)
                throw new ArgumentNullException(nameof(messageMetadataContainerFactory));
            _byteConverterSelector =
                byteConverterSelector ?? throw new ArgumentNullException(nameof(byteConverterSelector));

            _messageMetadataContainer = messageMetadataContainerFactory.Create<TMessage>();
        }

        /// <inheritdoc />
        public TMessage CreateMessage(byte[] payload, int messageId)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            MessageMetadata messageMetadata = _messageMetadataContainer.Get(messageId);

            TMessage message = (TMessage)Activator.CreateInstance(messageMetadata.Type);
            int offset = 0;

            foreach (var property in messageMetadata.Properties)
            {
                PropertyInfo propertyInfo = property.Key;
                PropertyMetadata propertyMetadata = property.Value;
                IByteConverter byteConverter = _byteConverterSelector.Select(propertyInfo.PropertyType);
                var bytesToConvert = new byte[propertyMetadata.Size];
                Array.Copy(payload, offset, bytesToConvert, 0, propertyMetadata.Size);
                var propertyValue = byteConverter.Convert(bytesToConvert);
                propertyInfo.SetValue(message, propertyValue);
                offset += propertyMetadata.Size;
            }

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] CreateBytes(TMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            throw new NotImplementedException();
        }
    }
}