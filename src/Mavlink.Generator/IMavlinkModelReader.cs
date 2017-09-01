// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkModelReader.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component responsible for reading specified dialect of mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Generator.Model;
using System.Collections.Generic;
using MavlinkModel = Mavlink.Generator.Model.Mavlink;

namespace Mavlink.Generator
{
    /// <summary>
    /// Interface of a component responsible for reading specified dialect of mavlink messages
    /// </summary>
    internal interface IMavlinkModelReader
    {
        /// <summary>
        /// Reads specified dialect of mavlink messages collection within all included dialects
        /// </summary>
        /// <param name="pathToXmls">Path to all dialects of malink messages defined as xml files</param>
        /// <param name="dialect">Root dialect to be read</param>
        /// <returns>Collection of malink messages within all included dialects</returns>
        IEnumerable<MavlinkModel> Read(string pathToXmls, DialectType dialect);
    }
}