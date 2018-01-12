using System;
using Mavlink.Common.Converters;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class CharArrayConverterTests
    {
        private static readonly IConverter Converter = new CharArrayConverter();

        public sealed class ConvertTests : CharArrayConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.ConvertBytes(null));
            }

            [Fact]
            public void Convert_IncorrectLenghtOfBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Utils.CreateByteArray(0, sizeof(char) * 1 + 1);
                Assert.Throws<ArgumentException>(() => Converter.ConvertBytes(bytesToConvert));
            }

            [Fact]
            public void Convert_FourZeroBytes_ReturnArrayWithTwoEmptyChars()
            {
                char[] expectedValue = { char.MinValue, char.MinValue };
                char[] convertedValue = (char[])Converter.ConvertBytes(Utils.CreateByteArray(0, 4));

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}