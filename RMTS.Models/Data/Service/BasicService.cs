using System.Collections.Generic;

namespace RMTS.Backend.Data.Service.Interface
{
    public interface BasicService<T>
    {
        bool Create(T item);
        bool Update(T item);
        bool Delete(int? id);
        IEnumerable<T> GetAll();
        T Find(int id);
    }
}