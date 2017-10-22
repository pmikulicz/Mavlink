using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class Int16ConverterTests
    {
        private static readonly IByteConverter Converter = new Int16Converter();

        public sealed class ConvertTests : Int16ConverterTests
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
                Assert.Throws<ArgumentException>(() =>
                    Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_TwoZeroBytes_ReturnCorrectValue()
            {
                const short expectedValue = 10;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                short convertedValue = (short)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}