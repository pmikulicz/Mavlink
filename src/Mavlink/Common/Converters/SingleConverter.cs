// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for float types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for float types
    /// </summary>
    internal sealed class SingleConverter : Converter<float>
    {
        private const int FloatSize = sizeof(float);

        /// <inheritdoc />
        public override float ConvertBytes(byte[] bytes)
        {
            if (bytes.Length != FloatSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to float which size is {FloatSize}");

            return BitConverter.ToSingle(bytes, 0);
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(float value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != FloatSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than float size which is {FloatSize}");

            return convertedValue;
        }
    }
}