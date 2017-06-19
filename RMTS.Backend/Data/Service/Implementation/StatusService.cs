using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public bool Create(Status item)
        {
            return statusRepository.Create(item);
        }

        public bool Update(Status item)
        {
            return statusRepository.Update(item);
        }

        public bool Delete(int? id)
        {
            return id != null && statusRepository.Delete(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return statusRepository.GetAll();
        }

        public Status Find(int id)
        {
            return statusRepository.Find(id);
        }
    }
}
