using System;

namespace Mavlink.Messages.Configuration
{
    internal sealed  class MessageConfigurator : IMessageConfigurator
    {
        private readonly MessageDetails _messageDetails;

        public MessageConfigurator(MessageDetails messageDetails)
        {
            _messageDetails = messageDetails ?? throw new ArgumentNullException(nameof(messageDetails));
        }

        public IMessageConfigurator SetName(string name)
        {
            _messageDetails.Name = name;

            return this;
        }

        public IMessageConfigurator SetId(int id)
        {
            _messageDetails.Id = id;

            return this;
        }

    }
}