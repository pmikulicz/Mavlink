// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entry.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents single entry of enumerator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Represents single entry of enumerator
    /// </summary>
    [XmlRoot(ElementName = "entry")]
    public sealed class Entry
    {
        /// <summary>
        /// Gets or sets enumerator entry value
        /// </summary>
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets enumerator entry name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets enumerator entry description
        /// </summary>
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets enumerator entry parameters
        /// </summary>
        [XmlElement(ElementName = "param")]
        public List<Parameter> Parameters { get; set; }
    }
}