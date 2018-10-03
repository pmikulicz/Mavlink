// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageProcessor.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common.Converters;
using Mavlink.Messages.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace Mavlink.Messages
{
    /// <summary>
    /// Processor which is responsible for creating mavlink messages
    /// </summary>
    internal sealed class MessageProcessor<TMessage> : IMessageProcessor<TMessage> where TMessage : IMavlinkMessage
    {
        private readonly IMessageMetadataContainer _messageMetadataContainer;
        private readonly Func<Type, IConverter> _selectConverter;

        public MessageProcessor(IMessageMetadataContainerFactory messageMetadataContainerFactory, Func<Type, IConverter> selectConverter)
        {
            if (messageMetadataContainerFactory == null)
                throw new ArgumentNullException(nameof(messageMetadataContainerFactory));
            _selectConverter = selectConverter
                ?? throw new ArgumentNullException(nameof(selectConverter));

            _messageMetadataContainer = messageMetadataContainerFactory.Create<TMessage>();
        }

        /// <inheritdoc />
        public TMessage CreateMessage(byte[] payload, int messageId)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            MessageMetadata messageMetadata = _messageMetadataContainer.Get(messageId);
            TMessage message = (TMessage)Activator.CreateInstance(messageMetadata.Type);
            var messageSize = messageMetadata.Properties.Select(p => p.Value.Size).Sum();
            int offset = 0;

            if (messageSize != payload.Length)
                throw new InvalidOperationException(
                    $"Payload size is different [{payload.Length}] than size of message from obtained metadata [{messageSize}]");

            foreach (var property in messageMetadata.Properties)
            {
                PropertyInfo propertyInfo = property.Key;
                PropertyMetadata propertyMetadata = property.Value;
                var converter = GetConverter(propertyInfo);
                var bytesToConvert = new byte[propertyMetadata.Size];
                Array.Copy(payload, offset, bytesToConvert, 0, propertyMetadata.Size);
                var propertyValue = converter.ConvertBytes(bytesToConvert);
                propertyInfo.SetValue(message, propertyValue);
                offset += propertyMetadata.Size;
            }

            return message;
        }

        /// <inheritdoc />
        public byte[] CreateBytes(TMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            MessageMetadata messageMetadata = _messageMetadataContainer.Get(message.Id.Value);
            var messageSize = messageMetadata.Properties.Select(p => p.Value.Size).Sum();
            var messageBytes = new byte[messageSize];
            int offset = 0;

            foreach (var property in messageMetadata.Properties)
            {
                PropertyInfo propertyInfo = property.Key;
                PropertyMetadata propertyMetadata = property.Value;
                var converter = GetConverter(propertyInfo);
                var valueToConvert = propertyInfo.GetValue(message);
                var valueAsBytes = converter.ConvertValue(valueToConvert);
                Array.Copy(valueAsBytes, 0, messageBytes, offset, valueAsBytes.Length);
                offset += propertyMetadata.Size;
            }

            return messageBytes;
        }

        private IConverter GetConverter(PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType.IsEnum
                ? propertyInfo.PropertyType.GetEnumUnderlyingType()
                : propertyInfo.PropertyType;
            var converter = _selectConverter(propertyType);

            if (converter == null)
                throw new InvalidOperationException(
                    $"Cannot find proper byte converter for property with name '{propertyInfo.Name}' and type '{propertyInfo.PropertyType.Name}'");

            return converter;
        }
    }
}