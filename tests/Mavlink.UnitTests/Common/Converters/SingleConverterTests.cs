using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class SingleConverterTests
    {
        private static readonly IByteConverter Converter = new SingleConverter();

        public sealed class ConvertTests : SingleConverterTests
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
                Assert.Throws<ArgumentException>(() => Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_FourBytes_ReturnCorrectValue()
            {
                const float expectedValue = 11.1f;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                float convertedValue = (float)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}