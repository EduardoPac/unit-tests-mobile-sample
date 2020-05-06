using System.Collections.Generic;
using MobileSample.Core.Enums;
using MobileSample.Core.Models;

namespace MobileSample.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetByConductorClass(EConductorClass conductorClass);
    }

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetByCompanyId(string id)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Import(List<User> list)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(User t)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetByConductorClass(EConductorClass conductorClass)
        {
            throw new System.NotImplementedException();
        }
    }
}