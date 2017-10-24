using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class BooleanConverterTests
    {
        private static readonly IConverter Converter = new BooleanConverter();

        public sealed class ConvertTests : BooleanConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.ConvertBytes(null));
            }

            [Fact]
            public void Convert_MoreThanOneByte_ThrowArgumentNullException()
            {
                var bytesToConvert = Utils.CreateByteArray(0, 2);
                Assert.Throws<ArgumentException>(() => Converter.ConvertBytes(bytesToConvert));
            }

            [Fact]
            public void Convert_OneByteAsZero_ReturnFalseVaue()
            {
                const bool expectedValue = false;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                bool convertedValue = (bool)Converter.ConvertBytes(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}