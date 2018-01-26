// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for byte types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for byte types
    /// </summary>
    internal sealed class ByteConverter : Converter<byte>
    {
        /// <inheritdoc />
        public override byte ConvertBytes(byte[] bytes)
        {
            const int byteSize = sizeof(byte);

            if (bytes.Length != byteSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to one byte which size is {byteSize}");

            return bytes.First();
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(byte value)
        {
            return new[] { value };
        }
    }
}