using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileSample.Core.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCompanyId(string id);
        Task<T> GetById(string id);
        Task<bool> Import(List<T> manufacturers);
        Task<bool> Save(T t);
        Task<bool> Remove(T t);
    }
}