using Mavlink.Messages.Models;

namespace Mavlink.Messages
{
    internal sealed class MessageFactory : IMessageFactory
    {
        public Message Create(byte[] payload, int messageId)
        {
            throw new System.NotImplementedException();
        }
    }
}