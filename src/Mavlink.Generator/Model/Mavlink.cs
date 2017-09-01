// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mavlink.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents specific set of mavlink messages within enumerator types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Represents specific set of mavlink messages within its enumerator types for single dialect
    /// </summary>
    [XmlRoot(ElementName = "mavlink")]
    public sealed class Mavlink
    {
        /// <summary>
        /// Gets or sets included mavlink dialects
        /// </summary>
        [XmlElement(ElementName = "include")]
        public List<DialectType> IncludeDialects { get; set; }

        /// <summary>
        /// Gets or sets mavlink enumerators of specified dialect
        /// </summary>
        [XmlArray("enums")]
        [XmlArrayItem("enum")]
        public List<Enumerator> Enumerators { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        [XmlArray("messages")]
        [XmlArrayItem("message")]
        public List<Message> Messages { get; set; }
    }
}