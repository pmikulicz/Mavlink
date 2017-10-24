// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseConverter.cs" company="Patryk Mikulicz">
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
    internal abstract class BaseConverter<T> : IConverter
    {
        /// <inheritdoc />
        public object ConvertBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            return RunByteArrayConversion(bytes);
        }

        public byte[] ConvertValue(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return RunValueConversion((T)value);
        }

        /// <inheritdoc />
        public Type Type => typeof(T);

        protected abstract T RunByteArrayConversion(byte[] bytes);

        protected abstract byte[] RunValueConversion(T value);
    }
}