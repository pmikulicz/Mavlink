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
    internal sealed class DoubleConverter : ByteConverter<double>
    {
        protected override double RunConversion(byte[] bytes)
        {
            const int doubleSize = sizeof(double);

            if (bytes.Length != doubleSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to double which size is {doubleSize}");

            return BitConverter.ToDouble(bytes, 0);
        }
    }
}