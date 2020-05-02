using FluentAssertions;
using MobileSample.Test.Util;
using Xunit;

namespace MobileSample.Test.Entities
{
    public interface IVehicleTests : IBaseEntitiesTests
    {
        void PropertiesRequiredInvalid(string id, string companyId, string name, string manufacturerId);
    }
    
    public class VehicleTests : BaseTests, IVehicleTests
    {
        [Fact]
        public void PropertiesRequiredValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();

            bool result = vehicle.ValidatePropertiesRequired();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public void PropertiesRequiredInvalid(string id, string companyId, string name, string manufacturerId)
        {
            var vehicle = EntitiesFactory.GetNewVehicleParametrized(id, name, companyId, manufacturerId);

            bool result = vehicle.ValidatePropertiesRequired();
            result.Should().BeFalse();
        }
    }
}