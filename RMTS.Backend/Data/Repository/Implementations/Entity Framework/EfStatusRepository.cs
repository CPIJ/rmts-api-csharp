using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Implementations.Entity_Framework
{
    public class EfStatusRepository : IStatusRepository
    {
        public bool Create(Status item)
        {
            using (var context = new RmtsContext())
            {
                context.Statuses.Add(item);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Status item)
        {
            using (var context = new RmtsContext())
            {
                var foundStatus = context.Statuses.FirstOrDefault(s => s.Id == item.Id);
                if (foundStatus == null) return false;

                context.Entry(foundStatus).CurrentValues.SetValues(item);
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int? id)
        {
            using (var context = new RmtsContext())
            {
                var statusToDelete = context.Statuses.FirstOrDefault(s => s.Id == id);
                if (statusToDelete == null) return false;

                context.Statuses.Remove(statusToDelete);
                return context.SaveChanges() > 0;
            }
        }

        public IEnumerable<Status> GetAll()
        {
            using (var context = new RmtsContext())
            {
                return context.Statuses.ToList();
            }
        }

        public Status Find(int id)
        {
            using (var context = new RmtsContext())
            {
                return context.Statuses.Find(id);
            }
        }
    }
}
