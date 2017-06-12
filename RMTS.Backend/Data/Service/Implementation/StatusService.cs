using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IStatusService statusService;

        public bool Create(Status item)
        {
            return statusService.Create(item);
        }

        public bool Update(Status item)
        {
            return statusService.Update(item);
        }

        public bool Delete(int? id)
        {
            return id != null && statusService.Delete(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return statusService.GetAll();
        }

        public Status Find(int id)
        {
            return statusService.Find(id);
        }
    }
}
