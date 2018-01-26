// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Uint64Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for ulong types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for ulong types
    /// </summary>
    internal sealed class UInt64Converter : Converter<ulong>
    {
        private const int UlongSize = sizeof(ulong);

        /// <inheritdoc />
        public override ulong ConvertBytes(byte[] bytes)
        {
            if (bytes.Length != UlongSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to ulong which size is {UlongSize}");

            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(ulong value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != UlongSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than ulong size which is {UlongSize}");

            return convertedValue;
        }
    }
}