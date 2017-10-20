// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Abstract implementation of byte converter
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Abstract implementation of byte converter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class ByteConverter<T> : IByteConverter
    {
        /// <inheritdoc />
        public object Convert(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            //if (BitConverter.IsLittleEndian)
            //   Array.Reverse(bytes);

            return RunConversion(bytes);
        }

        /// <inheritdoc />
        public Type Type => typeof(T);

        protected abstract T RunConversion(byte[] bytes);
    }
}