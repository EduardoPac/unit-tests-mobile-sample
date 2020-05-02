using FluentAssertions;
using MobileSample.Test.Util;
using Xunit;

namespace MobileSample.Test.Entities
{
    internal interface IManufacturerTests : IBaseEntitiesTests
    {
        void PropertiesRequiredInvalid(string id, string companyId, string name, string country);
    }
    
    public class ManufacturerTests : BaseTests, IManufacturerTests
    {
        [Fact]
        public void PropertiesRequiredValid()
        {
            var manufacturer = EntitiesFactory.GetNewManufacturer();
            bool result = manufacturer.ValidatePropertiesRequired();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public void PropertiesRequiredInvalid(string id, string companyId, string name, string country)
        {
            var manufacturer = EntitiesFactory.GetNewManufacturerParameterized(id, companyId, name, country);
            bool result = manufacturer.ValidatePropertiesRequired();
            result.Should().BeFalse();
        }
    }
}