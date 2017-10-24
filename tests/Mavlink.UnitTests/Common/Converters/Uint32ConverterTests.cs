using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class UInt32ConverterTests
    {
        private static readonly IConverter Converter = new UInt32Converter();

        public sealed class ConvertTests : UInt32ConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.ConvertBytes(null));
            }

            [Fact]
            public void Convert_MoreThanFourBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Utils.CreateByteArray(0, 5);
                Assert.Throws<ArgumentException>(() =>
                    Converter.ConvertBytes(bytesToConvert));
            }

            [Fact]
            public void Convert_FourZeroBytes_ReturnsZeroVaue()
            {
                const uint expectedValue = 77;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                uint convertedValue = (uint)Converter.ConvertBytes(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}