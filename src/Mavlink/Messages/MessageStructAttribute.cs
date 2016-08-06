using System;

namespace Mavlink.Messages
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class MessageStructAttribute : Attribute
    {
        public MessageStructAttribute(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Type = type;
        }

        public Type Type { get; }
    }
}