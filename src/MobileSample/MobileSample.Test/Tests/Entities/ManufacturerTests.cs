using FluentAssertions;
using MobileSample.Test.Util;
using Xunit;

namespace MobileSample.Test.Entities
{
    internal interface IManufacturerTests : IBaseEntitiesTests
    {
        void EntitiesRequiredInvalid(string id, string companyId, string name, string country);
    }
    
    public class ManufacturerTests : BaseTests, IManufacturerTests
    {
        [Fact]
        public void EntitiesRequiredValid()
        {
            var manufacturer = EntitiesFactory.GetNewManufacturer();
            bool result = manufacturer.ValidateRequired();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public void EntitiesRequiredInvalid(string id, string companyId, string name, string country)
        {
            var manufacturer = EntitiesFactory.GetNewManufacturerParameterized(id, companyId, name, country);
            bool result = manufacturer.ValidateRequired();
            result.Should().BeFalse();
        }
    }
}