using System.Collections.Generic;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Implementations.Entity_Framework
{
    public interface IStatusRepository
    {
        bool Create(Status item);
        bool Delete(int? id);
        Status Find(int id);
        IEnumerable<Status> GetAll();
        bool Update(Status item);
    }
}