// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UInt32Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for uint types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for uint types
    /// </summary>
    internal sealed class UInt32Converter : ByteConverter<uint>
    {
        protected override uint RunConversion(byte[] bytes)
        {
            const int uintSize = sizeof(uint);

            if (bytes.Length != uintSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to uint which size is {uintSize}");

            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}