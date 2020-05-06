using System.Collections.Generic;
using MobileSample.Core.Enums;
using MobileSample.Core.Models;

namespace MobileSample.Core.Repositories
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetByIds(string[] ids);
        IEnumerable<Vehicle> GetByManufacturerId(string id);
        IEnumerable<Vehicle> GetByVehicleClass(EVehicleClass vehicleClass);
    }

    public class VehicleRepository : IVehicleRepository
    {
        public IEnumerable<Vehicle> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vehicle> GetByCompanyId(string id)
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Import(List<Vehicle> list)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Vehicle t)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vehicle> GetByIds(string[] ids)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vehicle> GetByManufacturerId(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vehicle> GetByVehicleClass(EVehicleClass vehicleClass)
        {
            throw new System.NotImplementedException();
        }
    }
}