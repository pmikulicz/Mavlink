// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents single parameter of an entry
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Represents single parameter of an entry
    /// </summary>
    [XmlRoot(ElementName = "param")]
    public sealed class Parameter
    {
        /// <summary>
        /// Gets or sets parameter index
        /// </summary>
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }

        /// <summary>
        /// Gets or sets parameter text
        /// </summary>
        [XmlText]
        public string Text { get; set; }
    }
}