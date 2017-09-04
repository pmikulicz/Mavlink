using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    public abstract class MessageConfiguration<T> : IMessageDetailsProvider where T : MavlinkMessage
    {
        private readonly MessageDetails _messageDetails = new MessageDetails(typeof(T));

        public abstract void Configure();

        protected IPropertyConfigurator Property<TY>(Expression<Func<T, TY>> selector)
        {
            var property = (PropertyInfo)((MemberExpression)selector.Body).Member;

            if (_messageDetails.Properties.ContainsKey(property))
                return new PropertyConfigurator(_messageDetails.Properties[property]);

            var propertyConfiguration = new PropertyDetails();
            _messageDetails.Properties.Add(property, propertyConfiguration);

            return new PropertyConfigurator(propertyConfiguration);
        }

        protected IMessageConfigurator Message()
        {
            return new MessageConfigurator(_messageDetails);
        }

        MessageDetails IMessageDetailsProvider.Provide()
        {
            return _messageDetails;
        }
    }
}