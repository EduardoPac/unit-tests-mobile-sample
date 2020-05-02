using System;
using System.Collections.Generic;
using FluentAssertions;
using MobileSample.Core.Models;
using MobileSample.Test.Util;
using Xunit;

namespace MobileSample.Test.Entities
{
    internal interface IUserTests : IBaseEntitiesTests
    {
        void PropertiesRequiredInvalid(string id, string companyId, string name, bool hasArrayIdVehicles);
    }
    
    public class UserTests : BaseTests, IUserTests
    {
        [Fact]
        public void PropertiesRequiredValid()
        {
            var user = EntitiesFactory.GetNewUser();
            
            bool result = user.ValidatePropertiesRequired();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null,"test","test",true)]
        [InlineData("test",null,"test",true)]
        [InlineData("test","test",null,true)]
        [InlineData("test","test","test",false)]
        public void PropertiesRequiredInvalid(string id, string companyId, string name, bool hasArrayIdVehicles)
        {
            string[] idsVehicles = hasArrayIdVehicles ? EntitiesFactory.GetArrayStringIds(2) : new string [] { };
            var user = EntitiesFactory.GetNewUserParameterized(id, companyId, name, idsVehicles);
            
            bool result = user.ValidatePropertiesRequired();
            result.Should().BeFalse();
        }
    }
}