// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for short types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for short types
    /// </summary>
    internal sealed class Int16Converter : ByteConverter<short>
    {
        protected override short RunConversion(byte[] bytes)
        {
            const int shortSize = sizeof(short);

            if (bytes.Length != shortSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to short which size is {shortSize}");

            return BitConverter.ToInt16(bytes, 0);
        }
    }
}