using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileSample.Core.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> Import(List<T> list);
        Task<bool> Save(T t);
        Task<bool> Remove(T t);
    }
}