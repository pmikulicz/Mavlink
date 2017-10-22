using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class UInt16ConverterTests
    {
        private static readonly IByteConverter Converter = new UInt16Converter();

        public sealed class ConvertTests : UInt16ConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.Convert(null));
            }

            [Fact]
            public void Convert_MoreThanFourBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Helpers.CreateByteArray(0, 3);
                Assert.Throws<ArgumentException>(() =>
                    Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_TwoZeroBytes_ReturnsZeroVaue()
            {
                const ushort expectedValue = 11;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                ushort convertedValue = (ushort)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}