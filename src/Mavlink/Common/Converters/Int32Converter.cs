// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Int32Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for int types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for int types
    /// </summary>
    internal sealed class Int32Converter : Converter<int>
    {
        private const int IntSize = sizeof(int);

        /// <inheritdoc />
        public override int ConvertBytes(byte[] bytes)
        {
            if (bytes.Length != IntSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to int which size is {IntSize}");

            return BitConverter.ToInt32(bytes, 0);
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(int value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != IntSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than int size which is {IntSize}");

            return convertedValue;
        }
    }
}