// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for char types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for char types
    /// </summary>
    internal sealed class CharConverter : BaseConverter<char>
    {
        private const int CharSize = sizeof(char);

        protected override char RunByteArrayConversion(byte[] bytes)
        {
            if (bytes.Length != CharSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to char which size is {CharSize}");

            return BitConverter.ToChar(bytes, 0);
        }

        protected override byte[] RunValueConversion(char value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != CharSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than char size which is {CharSize}");

            return convertedValue;
        }
    }
}