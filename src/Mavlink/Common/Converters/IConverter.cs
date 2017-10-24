// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IByteConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which converts byte array to a value and from value to byte array for specific type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Interface of a component which converts byte array to a value and from value to byte array for specific type
    /// </summary>
    internal interface IConverter
    {
        /// <summary>
        /// Converts byte array to a value
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Converted value as an object</returns>
        object ConvertBytes(byte[] bytes);

        /// <summary>
        /// Converts value to byte array
        ///  </summary>
        /// <param name="value">Value to be converterd</param>
        /// <returns>Converted value as byte array</returns>
        byte[] ConvertValue(object value);

        /// <summary>
        /// Gets type for which the converter is dedicated
        /// </summary>
        Type Type { get; }
    }
}