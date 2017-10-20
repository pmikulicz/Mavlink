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
    internal sealed class CharConverter : ByteConverter<char>
    {
        protected override char RunConversion(byte[] bytes)
        {
            const int charSize = sizeof(char);

            if (bytes.Length != charSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to char which size is {charSize}");

            return BitConverter.ToChar(bytes, 0);
        }
    }
}