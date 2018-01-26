// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for short types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for short types
    /// </summary>
    internal sealed class Int16Converter : Converter<short>
    {
        private const int ShortSize = sizeof(short);

        /// <inheritdoc />
        public override short ConvertBytes(byte[] bytes)
        {
            if (bytes.Length != ShortSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to short which size is {ShortSize}");

            return BitConverter.ToInt16(bytes, 0);
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(short value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != ShortSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than short size which is {ShortSize}");

            return convertedValue;
        }
    }
}