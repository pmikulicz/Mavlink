// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageStructAttribute.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//  Specifies a mavlink message structure with appropriate structure type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Messages
{
    /// <summary>
    /// Specifies a mavlink message structure with appropriate structure type
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal class MessageStructAttribute : Attribute
    {
        public MessageStructAttribute(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Type = type;
        }

        /// <summary>
        /// Gets structure type
        /// </summary>
        public Type Type { get; }
    }
}