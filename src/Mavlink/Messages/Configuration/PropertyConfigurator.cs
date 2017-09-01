using System;

namespace Mavlink.Messages.Configuration
{
    internal sealed class PropertyConfigurator : IPropertyConfigurator
    {
        private readonly PropertyDetails _propertyDetails;

        public PropertyConfigurator(PropertyDetails propertyDetails)
        {
            _propertyDetails = propertyDetails ?? throw new ArgumentNullException(nameof(propertyDetails));
        }

        public IPropertyConfigurator SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _propertyDetails.Name = name;

            return this;
        }

        public IPropertyConfigurator SetOrder(int order)
        {
            _propertyDetails.Order = order;

            return this;
        }

        public IPropertyConfigurator SetSize(int size)
        {
            _propertyDetails.Order = size;

            return this;
        }
    }
}