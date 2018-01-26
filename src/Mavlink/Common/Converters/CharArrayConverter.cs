// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharArrayConverter.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//    Represents converter dedicated for char array types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace Mavlink.Common.Converters
{
    /// <summary>
    /// Represents converter dedicated for char array types
    /// </summary>
    internal sealed class CharArrayConverter : Converter<char[]>
    {
        /// <inheritdoc />
        public override char[] ConvertBytes(byte[] bytes)
        {
            return Encoding.ASCII.GetChars(bytes);
        }

        /// <inheritdoc />
        public override byte[] ConvertValue(char[] value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
    }
}