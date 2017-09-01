// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enumerator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents enumerator model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Represents enumerator model
    /// </summary>
    [XmlRoot(ElementName = "enum")]
    public sealed class Enumerator
    {
        /// <summary>
        /// Gets or sets enumerator entries
        /// </summary>
        [XmlElement(ElementName = "entry")]
        public List<Entry> Entries { get; set; }

        /// <summary>
        /// Gets or sets enumerator name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets enumerator description
        /// </summary>
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }
}