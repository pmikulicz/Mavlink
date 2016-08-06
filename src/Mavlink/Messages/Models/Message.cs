using Mavlink.Messages.Types;

namespace Mavlink.Messages.Models
{
    public interface IMessage
    {
        /// <summary>
        /// Gets type of the message
        /// </summary>
        MessageId Id { get; }
    }
}