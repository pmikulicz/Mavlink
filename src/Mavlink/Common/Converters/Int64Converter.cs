// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Int64Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for long types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for long types
    /// </summary>
    internal sealed class Int64Converter : ByteConverter<long>
    {
        protected override long RunConversion(byte[] bytes)
        {
            const int longSize = sizeof(long);

            if (bytes.Length != longSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to long which size is {longSize}");

            return BitConverter.ToInt64(bytes, 0);
        }
    }
}