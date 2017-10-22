using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class UInt32ConverterTests
    {
        private static readonly IByteConverter Converter = new UInt32Converter();

        public sealed class ConvertTests : UInt32ConverterTests
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
            public void Convert_FourZeroBytes_ReturnsZeroVaue()
            {
                const uint expectedValue = 77;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                uint convertedValue = (uint)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}