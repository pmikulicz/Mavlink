using Mavlink.Common.Converters;
using System;
using Xunit;

namespace Mavlink.UnitTests.Common.Converters
{
    public class UInt64ConverterTests
    {
        private static readonly IByteConverter Converter = new UInt64Converter();

        public sealed class ConvertTests : UInt32ConverterTests
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
                Assert.Throws<ArgumentException>(() =>
                    Converter.Convert(bytesToConvert));
            }

            [Fact]
            public void Convert_EightBytes_ReturnCorrectValue()
            {
                const ulong expectedValue = 963258741;
                var bytesToConvert = BitConverter.GetBytes(expectedValue);
                ulong convertedValue = (ulong)Converter.Convert(bytesToConvert);

                Assert.Equal(expectedValue, convertedValue);
            }
        }
    }
}