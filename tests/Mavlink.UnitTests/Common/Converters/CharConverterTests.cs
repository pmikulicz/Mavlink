using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class CharConverterTests
    {
        private static readonly IConverter Converter = new CharConverter();

        public sealed class ConvertTests : CharConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.ConvertBytes(null));
            }

            [Fact]
            public void Convert_MoreThanTwoBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Utils.CreateByteArray(0, 3);
                Assert.Throws<ArgumentException>(() => Converter.ConvertBytes(bytesToConvert));
            }

            [Fact]
            public void Convert_TwoZeroBytes_ReturnEmptyChar()
            {
                const char expectedValue = char.MinValue;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                char convertedValue = (char)Converter.ConvertBytes(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}