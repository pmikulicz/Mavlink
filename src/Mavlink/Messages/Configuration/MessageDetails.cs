using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    internal sealed class MessageDetails
    {
        public MessageDetails(Type type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public Type Type { get; }

        public string Name { get; set; }

        public int Id { get; set; }

        public IDictionary<PropertyInfo, PropertyDetails> Properties { get; set; } =
            new Dictionary<PropertyInfo, PropertyDetails>(10);
    }
}