// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharArrayConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//    Represents converter dedicated for char array types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for byte types
    /// </summary>
    internal sealed class CharArrayConverter : BaseConverter<char[]>
    {
        protected override char[] RunByteArrayConversion(byte[] bytes)
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] RunValueConversion(char[] value)
        {
            throw new System.NotImplementedException();
        }
    }
}