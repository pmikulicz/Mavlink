// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Int32Converter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for int types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for int types
    /// </summary>
    internal sealed class Int32Converter : ByteConverter<int>
    {
        protected override int RunConversion(byte[] bytes)
        {
            const int intSize = sizeof(int);

            if (bytes.Length != intSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to int which size is {intSize}");

            return BitConverter.ToInt32(bytes, 0);
        }
    }
}