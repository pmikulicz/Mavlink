using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class Int32ConverterTests
    {
        private static readonly IByteConverter Converter = new Int32Converter();

        public sealed class ConvertTests : Int32ConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.Convert(null));
            }

            [Fact]
            public void Convert_MoreThanFourBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Helpers.CreateByteArray(0, 5);
                Assert.Throws<ArgumentException>(() =>
                    Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_FourZeroBytes_ReturnCorrectValue()
            {
                const int expectedValue = 66;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                int convertedValue = (int)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}