using System.Collections.Generic;
using FluentAssertions;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;
using MobileSample.Core.Services;
using MobileSample.Test.Util;
using Moq;
using Xunit;

namespace MobileSample.Test.Services
{
    internal interface IManufacturerServiceTests : IBaseServiceTests
    {
        void GetByCompanyIdInvalid(string id);
        void GetByIdInvalid(string id);
        void ImportInvalid(string id, string companyId, string name, string country);
        void SaveInvalid(string id, string companyId, string name, string country);
        void RemoveInvalid(string id);
    }

    public class ManufacturerServiceTests : BaseTests, IManufacturerServiceTests
    {
        #region Setup

        static readonly Mock<IManufacturerRepository> _manufacturedRepository = new Mock<IManufacturerRepository>();
        readonly ManufacturerService _manufacturerService = new ManufacturerService(_manufacturedRepository.Object);

        #endregion

        #region Valid

        [Fact]
        public async void GetAllValid()
        {
            var listReturns = new List<Manufacturer> {EntitiesFactory.GetNewManufacturer()};
            _manufacturedRepository.Setup(r => r.GetAll()).Returns(listReturns);

            IEnumerable<Manufacturer> result = await _manufacturerService.GetAll();
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByCompanyIdValid()
        {
            var manufactured = EntitiesFactory.GetNewManufacturer();
            var listReturns = new List<Manufacturer> {manufactured};
            _manufacturedRepository.Setup(r => r.GetByCompanyId(manufactured.CompanyId)).Returns(listReturns);

            IEnumerable<Manufacturer> result = await _manufacturerService.GetByCompanyId(manufactured.CompanyId);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByIdValid()
        {
            var manufacturer = EntitiesFactory.GetNewManufacturer();
            _manufacturedRepository.Setup(r => r.GetById(manufacturer.Id)).Returns(manufacturer);

            Manufacturer result = await _manufacturerService.GetById(manufacturer.Id);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void ImportValid()
        {
            var manufactured = EntitiesFactory.GetNewManufacturer();
            var listManufacturers = new List<Manufacturer> {manufactured};
            _manufacturedRepository.Setup(r => r.Import(listManufacturers)).Returns(true);

            bool result = await _manufacturerService.Import(listManufacturers);
            result.Should().BeTrue();
        }

        [Fact]
        public async void SaveValid()
        {
            var manufactured = EntitiesFactory.GetNewManufacturer();
            _manufacturedRepository.Setup(r => r.Save(manufactured)).Returns(true);

            bool result = await _manufacturerService.Save(manufactured);
            result.Should().BeTrue();
        }

        [Fact]
        public async void RemoveValid()
        {
            var manufactured = EntitiesFactory.GetNewManufacturer();
            _manufacturedRepository.Setup(r => r.Save(manufactured)).Returns(true);

            bool result = await _manufacturerService.Remove(manufactured);
            result.Should().BeTrue();
        }

        #endregion

        #region Invalid

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByCompanyIdInvalid(string id)
        {
            List<Manufacturer> returnList = EntitiesFactory.GetManufacturerList();
            _manufacturedRepository.Setup(r => r.GetByCompanyId(id)).Returns(returnList);

            IEnumerable<Manufacturer> result = await _manufacturerService.GetByCompanyId(id);
            result.Should().BeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByIdInvalid(string id)
        {
            var manufacturer = EntitiesFactory.GetNewManufacturer();
            _manufacturedRepository.Setup(r => r.GetById(id)).Returns(manufacturer);

            Manufacturer result = await _manufacturerService.GetById(id);
            result.Should().BeNull();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public async void ImportInvalid(string id, string companyId, string name, string country)
        {
            var manufacturedInvalid = EntitiesFactory.GetNewManufacturerParameterized(id, companyId, name, country);
            List<Manufacturer> manufacturedList = EntitiesFactory.GetManufacturerList();
            manufacturedList.Add(manufacturedInvalid);
            _manufacturedRepository.Setup(r => r.Import(manufacturedList)).Returns(true);

            bool result = await _manufacturerService.Import(manufacturedList);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public async void SaveInvalid(string id, string companyId, string name, string country)
        {
            var manufactured = EntitiesFactory.GetNewManufacturerParameterized(id, companyId, name, country);
            _manufacturedRepository.Setup(r => r.Save(manufactured)).Returns(true);

            bool result = await _manufacturerService.Save(manufactured);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void RemoveInvalid(string id)
        {
            var manufacturer = EntitiesFactory.GetNewManufacturer();
            manufacturer.Id = id;
            _manufacturedRepository.Setup(r => r.Save(manufacturer)).Returns(true);

            bool result = await _manufacturerService.Remove(manufacturer);
            result.Should().BeFalse();
        }

        #endregion
    }
}