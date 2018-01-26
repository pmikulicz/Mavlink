// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UInt16Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for ushort types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for ushort types
    /// </summary>
    internal sealed class UInt16Converter : Converter<ushort>
    {
        private const int UshortSize = sizeof(short);

        /// <inheritdoc />
        public override ushort ConvertBytes(byte[] bytes)
        {
            if (bytes.Length != UshortSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to ushort which size is {UshortSize}");

            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(ushort value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != UshortSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than ushort size which is {UshortSize}");

            return convertedValue;
        }
    }
}