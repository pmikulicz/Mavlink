using Mavlink.Messages.Dialects.Ardupilot;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    public sealed class HeartbeatMessageConfiguration : MavlinkMessageConfiguration<HeartbeatMessage>
    {
        public override void Configure()
        {
            Message().SetName("").SetId(1);

            Property(hm => hm.Autopilot).SetName("").SetOrder(1);
            Property(hm => hm.BaseMode).SetName("").SetOrder(2);
            Property(hb => hb.CustomMode).SetOrder(3).SetName("gfdsfds");
        }
    }

    public sealed class ParamRequestReadMessageConfiguration : MavlinkMessageConfiguration<ParamRequestReadMessage>
    {
        public override void Configure()
        {
            Message().SetId(12).SetName("");

            Property(p => p.ParamId).SetOrder(1).SetSize(14).SetName("fds");
        }
    }

    public abstract class MavlinkMessageConfiguration<T> : IMessageDetailsProvider where T : MavlinkMessage
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

    internal interface IMessageDetailsProvider
    {
        MessageDetails Provide();
    }
}