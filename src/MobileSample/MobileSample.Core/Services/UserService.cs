using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileSample.Core.Enums;
using MobileSample.Core.Models;
using MobileSample.Core.Repositories;

namespace MobileSample.Core.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<IEnumerable<User>> GetByConductorClass(EConductorClass conductorClass);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll() => await Task.Run(_userRepository.GetAll);

        public async Task<IEnumerable<User>> GetByCompanyId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _userRepository.GetByCompanyId(id));
        }

        public async Task<User> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await Task.Run(() => _userRepository.GetById(id));
        }

        public async Task<bool> Import(List<User> manufacturers)
        {
            if (manufacturers == null || manufacturers.Any(user => !user.ValidateRequired()))
                return false;

            return await Task.Run(() => _userRepository.Import(manufacturers));
        }

        public async Task<bool> Save(User user)
        {
            if (!user.ValidateRequired())
                return false;

            return await Task.Run(() => _userRepository.Save(user));
        }

        public async Task<bool> Remove(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Id))
                return false;

            user.Removed = true;
            return await Task.Run(() => _userRepository.Save(user));
        }

        public async Task<IEnumerable<User>> GetByConductorClass(EConductorClass conductorClass) =>
            await Task.Run(() => _userRepository.GetByConductorClass(conductorClass));
    }
}