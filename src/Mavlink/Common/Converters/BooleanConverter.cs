// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for bool types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for bool types
    /// </summary>
    internal sealed class BooleanConverter : ByteConverter<bool>
    {
        protected override bool RunConversion(byte[] bytes)
        {
            const int boolSize = sizeof(bool);

            if (bytes.Length != boolSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to bool which size is {boolSize}");

            return BitConverter.ToBoolean(bytes, 0);
        }
    }
}