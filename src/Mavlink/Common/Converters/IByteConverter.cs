// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IByteConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which converts byte array to a value of specific type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Interface of a component which converts byte array to a value of specific type
    /// </summary>
    internal interface IByteConverter
    {
        /// <summary>
        /// Converts byte array to a value of specified type
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Converted value as an object</returns>
        object Convert(byte[] bytes);

        /// <summary>
        /// Gets type for which the converter is dedicated
        /// </summary>
        Type Type { get; }
    }
}