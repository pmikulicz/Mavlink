using Mavlink.Messages.Models;

namespace Mavlink.Messages
{
    internal interface IMessageFactory
    {
        Message Create(byte[] payload, int messageId);
    }
}