// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents converter dedicated for float types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for float types
    /// </summary>
    internal sealed class SingleConverter : BaseConverter<float>
    {
        protected override float RunByteArrayConversion(byte[] bytes)
        {
            const int floatSize = sizeof(float);

            if (bytes.Length != floatSize)
                throw new ArgumentException(
                    $"Cannot convert byte array with length {bytes.Length} to float which size is {floatSize}");

            return BitConverter.ToSingle(bytes, 0);
        }

        protected override byte[] RunValueConversion(float value)
        {
            throw new NotImplementedException();
        }
    }
}