using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class UInt16ConverterTests
    {
        private static readonly IConverter Converter = new UInt16Converter();

        public sealed class ConvertTests : UInt16ConverterTests
        {
            [Fact]
            public void Convert_NullBytes_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => Converter.ConvertBytes(null));
            }

            [Fact]
            public void Convert_MoreThanFourBytes_ThrowArgumentNullException()
            {
                var bytesToConvert = Utils.CreateByteArray(0, 3);
                Assert.Throws<ArgumentException>(() =>
                    Converter.ConvertBytes(bytesToConvert));
            }

            [Fact]
            public void Convert_TwoZeroBytes_ReturnsZeroVaue()
            {
                const ushort expectedValue = 11;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                ushort convertedValue = (ushort)Converter.ConvertBytes(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}