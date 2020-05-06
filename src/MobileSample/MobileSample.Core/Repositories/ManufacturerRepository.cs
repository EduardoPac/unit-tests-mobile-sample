using System.Collections.Generic;
using MobileSample.Core.Models;

namespace MobileSample.Core.Repositories
{
    public interface IManufacturerRepository : IBaseRepository<Manufacturer>
    {
    }

    public class ManufacturerRepository : IManufacturerRepository
    {
        public IEnumerable<Manufacturer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetByCompanyId(string id)
        {
            throw new System.NotImplementedException();
        }

        public Manufacturer GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Import(List<Manufacturer> list)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Manufacturer t)
        {
            throw new System.NotImplementedException();
        }
    }
}