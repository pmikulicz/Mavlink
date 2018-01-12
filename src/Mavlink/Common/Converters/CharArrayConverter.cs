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
    internal sealed class CharArrayConverter : BaseConverter<char[]>
    {
        private const int CharSize = sizeof(char);

        protected override char[] RunByteArrayConversion(byte[] bytes)
        {
            return Encoding.ASCII.GetChars(bytes);
        }

        protected override byte[] RunValueConversion(char[] value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
    }
}