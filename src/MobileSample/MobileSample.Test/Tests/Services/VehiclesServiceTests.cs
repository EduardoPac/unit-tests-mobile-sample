using MobileSample.Core.Repositories;
using MobileSample.Core.Services;
using MobileSample.Test.Util;
using Moq;

namespace MobileSample.Test.Services
{
    internal interface IVehiclesServiceTests : IBaseServiceTests
    {
        void GetByIdsValid();
        void GetByManufacturerIdValid();
        void GetByVehicleClassValid();
        void GetByCompanyIdInvalid(string id);
        void GetByIdInvalid(string id);
        void ImportInvalid(string id, string companyId, string name, string manufacturerId, int numItems);
        void SaveInvalid(string id, string companyId, string name, string manufacturerId);
        void RemoveInvalid(string id);
        void GetByIdsInvalid(string[] ids);
        void GetByManufacturerIdInvalid(string id);
    }
    
    public class VehiclesServiceTests : BaseTests, IVehiclesServiceTests
    {
        #region Setup

        static readonly Mock<IVehicleRepository> _vehicleRepository = new Mock<IVehicleRepository>();
        readonly VehicleService _vehicleService = new VehicleService(_vehicleRepository.Object);

        #endregion
        
        public void GetAllValid()
        {
            throw new System.NotImplementedException();
        }

        public void GetByCompanyIdValid()
        {
            throw new System.NotImplementedException();
        }

        public void GetByIdValid()
        {
            throw new System.NotImplementedException();
        }

        public void ImportValid()
        {
            throw new System.NotImplementedException();
        }

        public void SaveValid()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveValid()
        {
            throw new System.NotImplementedException();
        }

        public void GetByIdsValid()
        {
            throw new System.NotImplementedException();
        }

        public void GetByManufacturerIdValid()
        {
            throw new System.NotImplementedException();
        }

        public void GetByVehicleClassValid()
        {
            throw new System.NotImplementedException();
        }

        public void GetByCompanyIdInvalid(string id)
        {
            throw new System.NotImplementedException();
        }

        public void GetByIdInvalid(string id)
        {
            throw new System.NotImplementedException();
        }

        public void ImportInvalid(string id, string companyId, string name, string manufacturerId, int numItems)
        {
            throw new System.NotImplementedException();
        }

        public void SaveInvalid(string id, string companyId, string name, string manufacturerId)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveInvalid(string id)
        {
            throw new System.NotImplementedException();
        }

        public void GetByIdsInvalid(string[] ids)
        {
            throw new System.NotImplementedException();
        }

        public void GetByManufacturerIdInvalid(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}