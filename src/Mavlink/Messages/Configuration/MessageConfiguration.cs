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
using System.Linq.Expressions;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Abstract implementation of mavlink message configuration. It is base class which needs be be inherited in delivered
    /// configurations of all mavlink message types
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable once InheritdocConsiderUsage
    public abstract class MessageConfiguration<T> : IMessageMetadataProvider where T : MavlinkMessage
    {
        private readonly MessageMetadata _messageMetadata = new MessageMetadata(typeof(T));

        public abstract void Configure();

        /// <summary>
        /// Configures single property of mavlink message
        /// </summary>
        /// <typeparam name="TY">Type of property</typeparam>
        /// <param name="selector">Selector which indicates which property is configured</param>
        /// <returns>Instance of property metadata configurator for fluet api</returns>
        protected IPropertyMetadataConfigurator Property<TY>(Expression<Func<T, TY>> selector)
        {
            var property = (PropertyInfo)((MemberExpression)selector.Body).Member;

            if (_messageMetadata.Properties.ContainsKey(property))
                return new PropertyMetadataConfigurator(_messageMetadata.Properties[property]);

            var propertyConfiguration = new PropertyMetadata();
            _messageMetadata.Properties.Add(property, propertyConfiguration);

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