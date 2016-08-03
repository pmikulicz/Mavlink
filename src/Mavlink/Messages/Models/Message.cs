namespace Mavlink.Messages.Models
{
    public abstract class Message
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public abstract int Id { get; }
    }
}