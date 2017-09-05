// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//    Component which allows to configure property metadata of a mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages.Configuration
{
    /// <inheritdoc />
    internal sealed class PropertyMetadataConfigurator : IPropertyMetadataConfigurator
    {
        private readonly PropertyMetadata _propertyMetadata;

        public PropertyMetadataConfigurator(PropertyMetadata propertyMetadata)
        {
            _propertyMetadata = propertyMetadata ?? throw new ArgumentNullException(nameof(propertyMetadata));
        }

        /// <inheritdoc />
        public IPropertyMetadataConfigurator SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _propertyMetadata.Name = name;

            return this;
        }

        /// <inheritdoc />
        public IPropertyMetadataConfigurator SetOrder(int order)
        {
            if (order < 1)
                throw new ArgumentException("Order number should start with 1 and cannot be negative number");

            _propertyMetadata.Order = order;

            return this;
        }

        /// <inheritdoc />
        public IPropertyMetadataConfigurator SetSize(int size)
        {
            if (size < 1)
                throw new ArgumentException("Size should be greater than 0");

            _propertyMetadata.Size = size;

            return this;
        }
    }
}