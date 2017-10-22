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
    internal sealed class UInt64Converter : ByteConverter<ulong>
    {
        protected override ulong RunConversion(byte[] bytes)
        {
            const int ulongSize = sizeof(ulong);

            if (bytes.Length != ulongSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to ulong which size is {ulongSize}");

            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}