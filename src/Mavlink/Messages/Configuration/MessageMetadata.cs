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
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Model which represents message metadata
    /// </summary>
    internal sealed class MessageMetadata
    {
        public MessageMetadata(Type type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
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
        public IDictionary<PropertyInfo, PropertyMetadata> Properties { get; } =
            new Dictionary<PropertyInfo, PropertyMetadata>(10);
    }
}