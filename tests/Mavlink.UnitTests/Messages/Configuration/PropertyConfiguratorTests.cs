using Mavlink.Messages.Configuration;
using System;
using Xunit;

namespace Mavlink.UnitTests.Messages.Configuration
{
    public class PropertyConfiguratorTests
    {
        private static IPropertyConfigurator _propertyConfigurator = new PropertyConfigurator(new PropertyDetails());

        public sealed class SetNameTests : PropertyConfiguratorTests
        {
            [Fact]
            public void SetName_NullName_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _propertyConfigurator.SetName(null));
            }

            [Fact]
            public void SetName_EmptyString_ThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => _propertyConfigurator.SetName(string.Empty));
            }

            [Fact]
            public void SetName_CorrectName_Ok()
            {
                var propertyDetails = new PropertyDetails();
                _propertyConfigurator = new PropertyConfigurator(propertyDetails);
                var expectedPropertyName = "type";
                _propertyConfigurator.SetName(expectedPropertyName);

                Assert.Equal(expectedPropertyName, propertyDetails.Name);
            }
        }

        public sealed class SetOrderTests : PropertyConfiguratorTests
        {
            [Fact]
            public void SetOrder_ZeroValue_ThrowArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _propertyConfigurator.SetOrder(0));
            }

            [Fact]
            public void SetOrder_NegativeValue_ThrowArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _propertyConfigurator.SetOrder(-1));
            }

            [Fact]
            public void SetOrder_CorrectValue_Ok()
            {
                var propertyDetails = new PropertyDetails();
                _propertyConfigurator = new PropertyConfigurator(propertyDetails);
                var expectedPropertyOrder = 1;
                _propertyConfigurator.SetOrder(expectedPropertyOrder);

                Assert.Equal(expectedPropertyOrder, propertyDetails.Order);
            }
        }

        public sealed class SetSizeTests : PropertyConfiguratorTests
        {
            [Fact]
            public void SetSize_ZeroValue_ThrowArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _propertyConfigurator.SetSize(0));
            }

            [Fact]
            public void SetSize_CorrectValue_Ok()
            {
                var propertyDetails = new PropertyDetails();
                _propertyConfigurator = new PropertyConfigurator(propertyDetails);
                var expectedPropertySize = 4;
                _propertyConfigurator.SetSize(expectedPropertySize);

                Assert.Equal(expectedPropertySize, propertyDetails.Size);
            }
        }
    }
}