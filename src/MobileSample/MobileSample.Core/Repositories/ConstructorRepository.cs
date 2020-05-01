using System.Collections.Generic;
using MobileSample.Core.Models;

namespace MobileSample.Core.Repositories
{
    public interface IConstructorRepository : IBaseRepository<Constructor>
    {
    }

    public class ConstructorRepository : IConstructorRepository
    {
        public IEnumerable<Constructor> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Constructor GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Import(List<Constructor> list)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Constructor t)
        {
            throw new System.NotImplementedException();
        }
    }
}