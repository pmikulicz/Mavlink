using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class DoubleConverterTests
    {
        private static readonly IConverter Converter = new DoubleConverter();

        public sealed class ConvertTests : DoubleConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.ConvertBytes(null));
            }

            [Fact]
            public void Convert_MoreThanEightBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Utils.CreateByteArray(0, 9);
                Assert.Throws<ArgumentException>(() => Converter.ConvertBytes(bytesToConvert));
            }

            [Fact]
            public void Convert_FourBytes_ReturnCorrectValue()
            {
                const double expectedValue = 12.2d;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                double convertedValue = (double)Converter.ConvertBytes(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}