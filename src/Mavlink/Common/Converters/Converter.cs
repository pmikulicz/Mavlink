// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Abstract implementation of a converter
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Abstract implementation of a converter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class Converter<T> : IConverter
    {
        /// <inheritdoc />
        object IConverter.ConvertBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            return ConvertBytes(bytes);
        }

        byte[] IConverter.ConvertValue(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return ConvertValue((T)value);
        }

        /// <inheritdoc />
        public Type Type => typeof(T);

        /// <summary>
        ///  Converts byte array to a value
        /// </summary>
        /// <param name="bytes">Bytes to be converted</param>
        /// <returns>Strongly typed converted value</returns>
        public abstract T ConvertBytes(byte[] bytes);

        /// <summary>
        /// Converts value to byte array
        /// </summary>
        /// <param name="value">Strongly typed value to be converterd</param>
        /// <returns>Converted value as byte array</returns>
        public abstract byte[] ConvertValue(T value);
    }
}