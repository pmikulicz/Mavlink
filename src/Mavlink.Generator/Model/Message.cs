// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  Represents mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Represents mavlink message
    /// </summary>
    [XmlRoot(ElementName = "message")]
    public sealed class Message
    {
        /// <summary>
        /// Gets or sets mavlink id
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets mavlink description
        /// </summary>
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets mavlink name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets fields of mavlink message
        /// </summary>
        [XmlElement(ElementName = "field")]
        public List<Field> Fields { get; set; }
    }
}