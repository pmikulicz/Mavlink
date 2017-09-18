// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageId.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents abstract model of mavlink message id
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages
{
    /// <summary>
    /// Represents abstract model of mavlink message id
    /// </summary>
    public abstract class MessageId
    {
        /// <summary>
        /// Gets the value of message id
        /// </summary>
        public abstract  int Value { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is MessageId otherMessageId))
                return false;

            return Value == otherMessageId.Value;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return -1937169414 + Value.GetHashCode();
        }

        public static bool operator ==(MessageId first, MessageId second)
        {
            if ((object)first == null && (object)second == null)
                return true;

            if ((object)first == null || (object)second == null)
                return false;

            return first.Equals(second);
        }

        public static bool operator !=(MessageId first, MessageId second)
        {
            if ((object)first == null && (object)second == null)
                return false;

            if ((object)first == null || (object)second == null)
                return true;

            return !first.Equals(second);
        }
    }
}