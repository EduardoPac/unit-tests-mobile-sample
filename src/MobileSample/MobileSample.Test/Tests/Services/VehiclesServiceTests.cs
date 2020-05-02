using MobileSample.Test.Util;

namespace MobileSample.Test.Services
{
    internal interface IVehiclesServiceTests : IBaseServiceTests
    {
        void GetByCompanyIdInvalid(string id);
        void GetByIdInvalid(string id);
        void ImportInvalid(string id, string companyId, string name, string manufacturerId, int numItems);
        void SaveInvalid(string id, string companyId, string name, string manufacturerId);
        void RemoveInvalid(string id);
    }
    
    public class VehiclesServiceTests : BaseTests, IVehiclesServiceTests
    {
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
    }
}