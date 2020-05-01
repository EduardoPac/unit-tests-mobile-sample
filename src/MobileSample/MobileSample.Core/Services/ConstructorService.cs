using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;

namespace MobileSample.Core.Services
{
    public interface IConstructorService : IBaseService<Constructor>
    {
    }

    public class ConstructorService : IConstructorService
    {
        private readonly IConstructorRepository _constructorRepository;

        public ConstructorService(IConstructorRepository constructorRepository)
        {
            _constructorRepository = constructorRepository;
        }

        public async Task<IEnumerable<Constructor>> GetAll() => await Task.Run(_constructorRepository.GetAll);

        public async Task<Constructor> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _constructorRepository.GetById(id));
        }

        public async Task<bool> Import(List<Constructor> constructors)
        {
            if (constructors == null || constructors.Any(constructor => constructor.ValidateRequired()))
                return false;

            return await Task.Run(() => _constructorRepository.Import(constructors));
        }

        public async Task<bool> Save(Constructor constructor)
        {
            if (constructor.ValidateRequired())
                return false;

            return await Task.Run(() => _constructorRepository.Save(constructor));
        }

        public async Task<bool> Remove(Constructor constructor)
        {
            if (string.IsNullOrWhiteSpace(constructor.Id))
                return false;

            return await Task.Run(() => _constructorRepository.Save(constructor));
        }
    }
}