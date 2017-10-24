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
    internal sealed class BooleanConverter : BaseConverter<bool>
    {
        private const int BoolSize = sizeof(bool);

        protected override bool RunByteArrayConversion(byte[] bytes)
        {
            if (bytes.Length != BoolSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to bool which size is {BoolSize}");

            return BitConverter.ToBoolean(bytes, 0);
        }

        protected override byte[] RunValueConversion(bool value)
        {
            var convertedValue = BitConverter.GetBytes(value);

            if (convertedValue.Length != BoolSize)
                throw new ArgumentException(
                    $"Size of converted value as bytes {convertedValue.Length} is different than bool size which is {BoolSize}");

            return convertedValue;
        }
    }
}