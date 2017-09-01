// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Field.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents single field of a message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Represents single field of a message
    /// </summary>
    [XmlRoot(ElementName = "field")]
    public sealed class Field
    {
        /// <summary>
        /// Gets or sets type of field
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets name of field
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description of field
        /// </summary>
        [XmlText]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets units of field
        /// </summary>
        [XmlAttribute(AttributeName = "units")]
        public string Units { get; set; }

        /// <summary>
        /// Gets or sets enumerator type if field is enumerator, otherwise is null
        /// </summary>
        [XmlAttribute(AttributeName = "enum")]
        public string EnumeratorType { get; set; }

        /// <summary>
        /// Gets or sets display name
        /// </summary>
        [XmlAttribute(AttributeName = "display")]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets print format of field
        /// </summary>
        [XmlAttribute(AttributeName = "print_format")]
        public string PrintFormat { get; set; }
    }
}