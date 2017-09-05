// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyMetadata.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Model which represent single property metadata of mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Model which represent single property metadata of mavlink message
    /// </summary>
    internal sealed class PropertyMetadata
    {
        /// <summary>
        /// Gets or sets property name of mavlink message
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets property order of mavlink message
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets property size of mavlink message
        /// </summary>
        public int Size { get; set; }
    }
}