// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//    Component which allows to configure property details of a message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages.Configuration
{
    /// <inheritdoc />
    internal sealed class PropertyConfigurator : IPropertyConfigurator
    {
        private readonly PropertyDetails _propertyDetails;

        public PropertyConfigurator(PropertyDetails propertyDetails)
        {
            _propertyDetails = propertyDetails ?? throw new ArgumentNullException(nameof(propertyDetails));
        }

        /// <inheritdoc />
        public IPropertyConfigurator SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _propertyDetails.Name = name;

            return this;
        }

        /// <inheritdoc />
        public IPropertyConfigurator SetOrder(int order)
        {
            if (order < 1)
                throw new ArgumentException("Order number should start with 1 and cannot be negative number");

            _propertyDetails.Order = order;

            return this;
        }

        /// <inheritdoc />
        public IPropertyConfigurator SetSize(int size)
        {
            if (size < 1)
                throw new ArgumentException("Size should be greater than 0");

            _propertyDetails.Size = size;

            return this;
        }
    }
}