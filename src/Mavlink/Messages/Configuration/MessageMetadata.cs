// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMetadata.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Model which represents message metadata
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Model which represents message metadata
    /// </summary>
    internal sealed class MessageMetadata
    {
        private readonly IDictionary<PropertyInfo, PropertyMetadata> _internalProperties;

        public MessageMetadata(IDictionary<PropertyInfo, PropertyMetadata> properties, Type type)
        {
            _internalProperties = properties;
            Type = type;
        }

        /// <summary>
        /// Gets type of mavlink message
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Gets or sets mavlink message id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of mavlink message
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets mavlink message properties
        /// </summary>
        public IEnumerable<KeyValuePair<PropertyInfo, PropertyMetadata>> Properties
        {
            get
            {
                var propertiesList = _internalProperties.ToList();
                propertiesList.Sort((first, second) =>
                    first.Value.Order.CompareTo(second.Value.Order));

                return propertiesList;
            }
        }
    }
}