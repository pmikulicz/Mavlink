// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageConfiguration.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  Abstract implementation of mavlink message configuration. It is base class which needs be be inherited in delivered
//  configurations of all mavlink message types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Abstract implementation of mavlink message configuration. It is base class which needs be be inherited in delivered
    /// configurations of all mavlink message types
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public abstract class MessageConfiguration<TMessage> : IMessageConfiguration, IMessageMetadataProvider where TMessage : MavlinkMessage
    {
        private readonly IDictionary<PropertyInfo, PropertyMetadata> _properties;
        private readonly MessageMetadata _messageMetadata;

        protected MessageConfiguration()
        {
            _properties = new Dictionary<PropertyInfo, PropertyMetadata>(10);
            _messageMetadata = new MessageMetadata(_properties, typeof(TMessage));
        }

        public abstract void Configure();

        /// <summary>
        /// Configures single property of mavlink message
        /// </summary>
        /// <typeparam name="TY">Type of property</typeparam>
        /// <param name="selector">Selector which indicates which property is configured</param>
        /// <returns>Instance of property metadata configurator for fluet api</returns>
        protected IPropertyMetadataConfigurator Property<TY>(Expression<Func<TMessage, TY>> selector)
        {
            var property = (PropertyInfo)((MemberExpression)selector.Body).Member;

            if (_properties.ContainsKey(property))
                return new PropertyMetadataConfigurator(_properties[property]);

            var propertyConfiguration = new PropertyMetadata();
            _properties.Add(property, propertyConfiguration);

            return new PropertyMetadataConfigurator(propertyConfiguration);
        }

        /// <summary>
        /// Configures mavlink message
        /// </summary>
        /// <returns>Instance of message metadata configurator for fluet api</returns>
        protected IMessageMetadataConfigurator Message()
        {
            return new MessageMetadataMetadataConfigurator(_messageMetadata);
        }

        /// <inheritdoc />
        MessageMetadata IMessageMetadataProvider.Provide()
        {
            return _messageMetadata;
        }
    }
}