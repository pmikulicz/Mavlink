// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharArrayConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//    Represents converter dedicated for char array types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for char array types
    /// </summary>
    internal sealed class CharArrayConverter : BaseConverter<char[]>
    {
        private const int CharSize = sizeof(char);

        protected override char[] RunByteArrayConversion(byte[] bytes)
        {
            if (bytes.Length % CharSize != 0)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to char array because " +
                    "the size of byte array is not an multiple of the char size");

            int charArraySize = bytes.Length / CharSize;
            char[] convertedBytes = new char[charArraySize];

            for (int byteIndex = 0, charIndex = 0; byteIndex < bytes.Length; byteIndex += CharSize, charIndex++)
            {
                convertedBytes[charIndex] = BitConverter.ToChar(bytes.Skip(byteIndex).Take(CharSize).ToArray(), 0);
            }

            return convertedBytes;
        }

        protected override byte[] RunValueConversion(char[] value)
        {
            int byteArraySize = value.Length * CharSize;
            var convertedChars = new byte[byteArraySize];

            for (int charIndex = 0, byteIndex = 0; charIndex < value.Length; charIndex++, byteIndex += CharSize)
            {
                char charToConvert = value[charIndex];
                Array.Copy(BitConverter.GetBytes(charToConvert), convertedChars, byteIndex);
            }

            return convertedChars;
        }
    }
}