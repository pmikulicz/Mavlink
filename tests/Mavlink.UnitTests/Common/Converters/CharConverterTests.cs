using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class CharConverterTests
    {
        private static readonly IByteConverter Converter = new CharConverter();

        public sealed class ConvertTests : CharConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.Convert(null));
            }

            [Fact]
            public void Convert_MoreThanTwoBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Helpers.CreateByteArray(0, 3);
                Assert.Throws<ArgumentException>(() => Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_TwoZeroBytes_ReturnEmptyChar()
            {
                const char expectedValue = char.MinValue;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                char convertedValue = (char)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}