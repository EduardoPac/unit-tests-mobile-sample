using MobileSample.Core.Repositories;
using MobileSample.Core.Services;
using MobileSample.Test.Util;
using Moq;

namespace MobileSample.Test.Services
{
    internal interface IUserServiceTests : IBaseServiceTests
    {
        void GetByConductorClassValid();
        void GetByCompanyIdInvalid(string id);
        void GetByIdInvalid(string id);
        void ImportInvalid(string id, string companyId, string name, bool hasArrayIdVehicles, int numberItems);
        void SaveInvalid(string id, string companyId, string name, bool hasArrayIdVehicles);
        void RemoveInvalid(string id);
    }

    public class UserServiceTests : BaseTests, IUserServiceTests
    {
        #region Setup

        static readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        readonly UserService _userService = new UserService(_userRepository.Object);

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

        public void GetByConductorClassValid()
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

        public void ImportInvalid(string id, string companyId, string name, bool hasArrayIdVehicles, int numberItems)
        {
            throw new System.NotImplementedException();
        }

        public void SaveInvalid(string id, string companyId, string name, bool hasArrayIdVehicles)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveInvalid(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}