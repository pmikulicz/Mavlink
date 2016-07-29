namespace Mavlink.Messages
{
    public abstract class Message
    {
        /// <summary>
        /// Gets id of the message
        /// </summary>
        public abstract int Id { get; }
    }
}