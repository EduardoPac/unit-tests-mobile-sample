using System.Collections.Generic;
using FluentAssertions;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;
using MobileSample.Core.Services;
using MobileSample.Test.Util;
using NSubstitute;
using Xunit;

namespace MobileSample.Test.Services
{
    internal interface IUserServiceTests : IBaseServiceTests
    {
        void GetByConductorClassValid();
        void GetByCompanyIdInvalid(string id);
        void GetByIdInvalid(string id);
        void ImportInvalid(string id, string companyId, string name, bool hasArrayIdVehicles);
        void SaveInvalid(string id, string companyId, string name, bool hasArrayIdVehicles);
        void RemoveInvalid(string id);
    }

    public class UserServiceTests : BaseTests, IUserServiceTests
    {
        #region Setup

        static readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        readonly UserService _userService = new UserService(_userRepository);

        #endregion

        #region Valid

        [Fact]
        public async void GetAllValid()
        {
            var listReturns = new List<User> {EntitiesFactory.GetNewUser()};
            _userRepository.GetAll().Returns(listReturns);

            IEnumerable<User> result = await _userService.GetAll();
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByCompanyIdValid()
        {
            var user = EntitiesFactory.GetNewUser();
            var listReturns = new List<User> {user};
            _userRepository.GetByCompanyId(user.CompanyId).Returns(listReturns);

            IEnumerable<User> result = await _userService.GetByCompanyId(user.CompanyId);
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByIdValid()
        {
            var user = EntitiesFactory.GetNewUser();
            _userRepository.GetById(user.Id).Returns(user);

            var result = await _userService.GetById(user.Id);
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async void ImportValid()
        {
            List<User> users = EntitiesFactory.GetUserList();
            _userRepository.Import(users).Returns(true);

            bool result = await _userService.Import(users);
            
            result.Should().BeTrue();
        }

        [Fact]
        public async void SaveValid()
        {
            var user = EntitiesFactory.GetNewUser();
            _userRepository.Save(user).Returns(true);

            bool result = await _userService.Save(user);
            
            result.Should().BeTrue();
        }

        [Fact]
        public async void RemoveValid()
        {
            var user = EntitiesFactory.GetNewUser();
            _userRepository.Save(user).Returns(true);

            bool result = await _userService.Remove(user);
            
            result.Should().BeTrue();
        }

        [Fact]
        public async void GetByConductorClassValid()
        {
            List<User> listReturn = EntitiesFactory.GetUserList();
            var user = EntitiesFactory.GetNewUser();
            listReturn.Add(user);
            _userRepository.GetByConductorClass(user.ConductorClass).Returns(listReturn);

            IEnumerable<User> result = await _userService.GetByConductorClass(user.ConductorClass);
            
            result.Should().NotBeNull();
        }

        #endregion

        #region Invalid

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByCompanyIdInvalid(string id)
        {
            List<User> userList = EntitiesFactory.GetUserList();
            _userRepository.GetByCompanyId(id).Returns(userList);

            IEnumerable<User> result = await _userService.GetByCompanyId(id);

            result.Should().BeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByIdInvalid(string id)
        {
            var user = EntitiesFactory.GetNewUser();
            _userRepository.GetById(id).Returns(user);

            var result = await _userService.GetById(id);

            result.Should().BeNull();
        }

        [Theory]
        [InlineData(null,"test","test",true)]
        [InlineData("test",null,"test",true)]
        [InlineData("test","test",null,true)]
        [InlineData("test","test","test",false)]
        public async void ImportInvalid(string id, string companyId, string name, bool hasArrayIdVehicles)
        {
            string[] idsVehicles = hasArrayIdVehicles ? EntitiesFactory.GetArrayStringIds(2) : new string [] { };
            List<User> userList = EntitiesFactory.GetUserList();
            var user = EntitiesFactory.GetNewUserParameterized(id, companyId, name, idsVehicles);
            userList.Add(user);
            _userRepository.Import(userList).Returns(true);

            bool result = await _userService.Import(userList);
            
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null,"test","test",true)]
        [InlineData("test",null,"test",true)]
        [InlineData("test","test",null,true)]
        [InlineData("test","test","test",false)]
        public async void SaveInvalid(string id, string companyId, string name, bool hasArrayIdVehicles)
        {
            string[] idsVehicles = hasArrayIdVehicles ? EntitiesFactory.GetArrayStringIds(2) : new string [] { };
            var user = EntitiesFactory.GetNewUserParameterized(id, companyId, name, idsVehicles);
            _userRepository.Save(user).Returns(true);
            
            bool result = await _userService.Save(user);
            
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void RemoveInvalid(string id)
        {
            var user = EntitiesFactory.GetNewUser();
            user.Id = id;
            _userRepository.Save(user).Returns(true);

            bool result = await _userService.Remove(user);

            result.Should().BeFalse();
        }

        #endregion
        
    }
}