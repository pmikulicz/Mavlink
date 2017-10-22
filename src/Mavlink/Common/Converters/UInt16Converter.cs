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
    internal sealed class UInt16Converter : ByteConverter<ushort>
    {
        protected override ushort RunConversion(byte[] bytes)
        {
            const int ushortSize = sizeof(short);

            if (bytes.Length != ushortSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to ushort which size is {ushortSize}");

            return BitConverter.ToUInt16(bytes, 0);
        }
    }
}