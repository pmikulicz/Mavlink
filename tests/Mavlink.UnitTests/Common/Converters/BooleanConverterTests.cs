using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class BooleanConverterTests
    {
        private static readonly IByteConverter Converter = new BooleanConverter();

        public sealed class ConvertTests : BooleanConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.Convert(null));
            }

            [Fact]
            public void Convert_MoreThanOneByte_ThrowArgumentNullException()
            {
                var bytesToConvert = Helpers.CreateByteArray(0, 2);
                Assert.Throws<ArgumentException>(() => Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_OneByteAsZero_ReturnFalseVaue()
            {
                const bool expectedValue = false;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                bool convertedValue = (bool)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}