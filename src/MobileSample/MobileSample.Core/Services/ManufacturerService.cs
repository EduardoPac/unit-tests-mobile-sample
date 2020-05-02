using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;

namespace MobileSample.Core.Services
{
    public interface IManufacturerService : IBaseService<Manufacturer>
    {
    }

    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<IEnumerable<Manufacturer>> GetAll() => await Task.Run(_manufacturerRepository.GetAll);

        public async Task<IEnumerable<Manufacturer>> GetByCompanyId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _manufacturerRepository.GetByCompanyId(id));
        }

        public async Task<Manufacturer> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _manufacturerRepository.GetById(id));
        }

        public async Task<bool> Import(List<Manufacturer> manufacturers)
        {
            if (manufacturers == null || manufacturers.Any(manufacturer => !manufacturer.ValidatePropertiesRequired()))
                return false;

            return await Task.Run(() => _manufacturerRepository.Import(manufacturers));
        }

        public async Task<bool> Save(Manufacturer manufacturer)
        {
            if (!manufacturer.ValidatePropertiesRequired())
                return false;

            return await Task.Run(() => _manufacturerRepository.Save(manufacturer));
        }

        public async Task<bool> Remove(Manufacturer manufacturer)
        {
            if (string.IsNullOrWhiteSpace(manufacturer.Id))
                return false;

            return await Task.Run(() => _manufacturerRepository.Save(manufacturer));
        }
    }
}