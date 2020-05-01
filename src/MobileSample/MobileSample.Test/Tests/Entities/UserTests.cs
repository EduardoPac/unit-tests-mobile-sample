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
        void EntitiesRequiredInvalid(string id, string companyId, string name, bool hasArrayIdVehicles);
    }
    
    public class UserTests : BaseTests, IUserTests
    {
        [Fact]
        public void EntitiesRequiredValid()
        {
            var user = EntitiesFactory.GetNewUser();
            
            bool result = user.ValidateRequired();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("","test","test",true)]
        [InlineData("test","","test",true)]
        [InlineData("test","test","",true)]
        [InlineData("test","test","test",false)]
        [InlineData(null,"test","test",true)]
        [InlineData("test",null,"test",true)]
        [InlineData("test","test",null,true)]
        public void EntitiesRequiredInvalid(string id, string companyId, string name, bool hasArrayIdVehicles)
        {
            string[] idsVehicles = hasArrayIdVehicles ? EntitiesFactory.GetArrayStringIds(2) : new string [] { };
            var user = EntitiesFactory.GetNewUserParameterized(id, companyId, name, idsVehicles);
            
            bool result = user.ValidateRequired();
            result.Should().BeFalse();
        }
    }
}