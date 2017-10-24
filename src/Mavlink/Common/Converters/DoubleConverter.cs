// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for double types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for double types
    /// </summary>
    internal sealed class DoubleConverter : BaseConverter<double>
    {
        private const int DoubleSize = sizeof(double);

        protected override double RunByteArrayConversion(byte[] bytes)
        {
            if (bytes.Length != DoubleSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to double which size is {DoubleSize}");

            return BitConverter.ToDouble(bytes, 0);
        }

        protected override byte[] RunValueConversion(double value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != DoubleSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than double size which is {DoubleSize}");

            return convertedValue;
        }
    }
}