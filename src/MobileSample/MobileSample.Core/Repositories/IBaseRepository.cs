using System.Collections.Generic;

namespace MobileSample.Core.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCompanyId(string id);
        T GetById(string id);
        bool Import(List<T> list);
        bool Save(T t);
    }
}