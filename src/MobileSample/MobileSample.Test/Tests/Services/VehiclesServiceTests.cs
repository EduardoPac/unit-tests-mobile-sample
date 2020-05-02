using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;
using MobileSample.Core.Services;
using MobileSample.Test.Util;
using Moq;
using Xunit;

namespace MobileSample.Test.Services
{
    internal interface IVehiclesServiceTests : IBaseServiceTests
    {
        void GetByIdsValid();
        void GetByManufacturerIdValid();
        void GetByVehicleClassValid();
        void GetByCompanyIdInvalid(string id);
        void GetByIdInvalid(string id);
        void ImportInvalid(string id, string companyId, string name, string manufacturerId);
        void SaveInvalid(string id, string companyId, string name, string manufacturerId);
        void RemoveInvalid(string id);
        void GetByIdsInvalid();
        void GetByManufacturerIdInvalid(string id);
    }

    public class VehiclesServiceTests : BaseTests, IVehiclesServiceTests
    {
        #region Setup

        static readonly Mock<IVehicleRepository> _vehicleRepository = new Mock<IVehicleRepository>();
        readonly VehicleService _vehicleService = new VehicleService(_vehicleRepository.Object);

        #endregion

        #region Valid

        [Fact]
        public async void GetAllValid()
        {
            List<Vehicle> listReturn = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.GetAll()).Returns(listReturn);

            IEnumerable<Vehicle> result = await _vehicleService.GetAll();

            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByCompanyIdValid()
        {
            List<Vehicle> listReturn = EntitiesFactory.GetVehicleList();
            var vehicle = EntitiesFactory.GetNewVehicle();
            listReturn.Add(vehicle);
            _vehicleRepository.Setup(r => r.GetByCompanyId(vehicle.CompanyId)).Returns(listReturn);

            IEnumerable<Vehicle> result = await _vehicleService.GetByCompanyId(vehicle.CompanyId);

            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByIdValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            _vehicleRepository.Setup(r => r.GetById(vehicle.Id)).Returns(vehicle);

            var result = await _vehicleService.GetById(vehicle.Id);

            result.Should().NotBeNull();
        }

        [Fact]
        public async void ImportValid()
        {
            List<Vehicle> vehicles = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.Import(vehicles)).Returns(true);

            bool result = await _vehicleService.Import(vehicles);

            result.Should().BeTrue();
        }

        [Fact]
        public async void SaveValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            _vehicleRepository.Setup(r => r.Save(vehicle)).Returns(true);

            bool result = await _vehicleService.Save(vehicle);

            result.Should().BeTrue();
        }

        [Fact]
        public async void RemoveValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            _vehicleRepository.Setup(r => r.Save(vehicle)).Returns(true);

            bool result = await _vehicleService.Remove(vehicle);

            result.Should().BeTrue();
        }

        [Fact]
        public async void GetByIdsValid()
        {
            List<Vehicle> listReturn = EntitiesFactory.GetVehicleList();
            string[] ids = EntitiesFactory.GetArrayStringIds();
            _vehicleRepository.Setup(r => r.GetByIds(ids)).Returns(listReturn);

            IEnumerable<Vehicle> result = await _vehicleService.GetByIds(ids);

            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByManufacturerIdValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            List<Vehicle> listReturn = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.GetByManufacturerId(vehicle.ManufacturerId)).Returns(listReturn);

            IEnumerable<Vehicle> result = await _vehicleService.GetByManufacturerId(vehicle.ManufacturerId);

            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetByVehicleClassValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            List<Vehicle> listReturn = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.GetByVehicleClass(vehicle.VehicleClass)).Returns(listReturn);

            IEnumerable<Vehicle> result = await _vehicleService.GetByVehicleClass(vehicle.VehicleClass);

            result.Should().NotBeNull();
        }

        #endregion

        #region Invalid

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByCompanyIdInvalid(string id)
        {
            List<Vehicle> returnList = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.GetByCompanyId(id)).Returns(returnList);

            IEnumerable<Vehicle> result = await _vehicleService.GetByCompanyId(id);

            result.Should().BeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByIdInvalid(string id)
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            _vehicleRepository.Setup(r => r.GetById(id)).Returns(vehicle);

            var result = await _vehicleService.GetById(id);

            result.Should().BeNull();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public async void ImportInvalid(string id, string companyId, string name, string manufacturerId)
        {
            List<Vehicle> vehicleList = EntitiesFactory.GetVehicleList();
            var vehicle = EntitiesFactory.GetNewVehicleParametrized(id, name, companyId, manufacturerId);
            vehicleList.Add(vehicle);
            _vehicleRepository.Setup(r => r.Import(vehicleList)).Returns(true);

            bool result = await _vehicleService.Import(vehicleList);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public async void SaveInvalid(string id, string companyId, string name, string manufacturerId)
        {
            var vehicle = EntitiesFactory.GetNewVehicleParametrized(id, name, companyId, manufacturerId);
            _vehicleRepository.Setup(r => r.Save(vehicle)).Returns(true);

            bool result = await _vehicleService.Save(vehicle);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void RemoveInvalid(string id)
        {
            var vehicle = EntitiesFactory.GetNewVehicle();
            vehicle.Id = id;
            _vehicleRepository.Setup(r => r.Save(vehicle)).Returns(true);

            bool result = await _vehicleService.Remove(vehicle);

            result.Should().BeFalse();
        }

        [Fact]
        public async void GetByIdsInvalid()
        {
            List<Vehicle> returnList = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.GetByIds(null)).Returns(returnList);

            IEnumerable<Vehicle> result = await _vehicleService.GetByIds(null);

            result.Should().BeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void GetByManufacturerIdInvalid(string id)
        {
            List<Vehicle> returnList = EntitiesFactory.GetVehicleList();
            _vehicleRepository.Setup(r => r.GetByManufacturerId(id)).Returns(returnList);

            IEnumerable<Vehicle> result = await _vehicleService.GetByManufacturerId(id);

            result.Should().BeNull();
        }

        #endregion
    }
}