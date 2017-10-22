using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class Int64ConverterTests
    {
        private static readonly IByteConverter Converter = new Int64Converter();

        public sealed class ConvertTests : Int64ConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.Convert(null));
            }

            [Fact]
            public void Convert_MoreThanEightBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Helpers.CreateByteArray(0, 9);
                Assert.Throws<ArgumentException>(() => Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_EightZeroBytes_ReturnCorrectValue()
            {
                const long expectedValue = 666;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                long convertedValue = (long)Converter.Convert(bytesToConvert);
                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}