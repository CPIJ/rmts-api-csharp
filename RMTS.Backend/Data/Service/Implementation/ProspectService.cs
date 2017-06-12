using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
    public class ProspectService : IProspectService
    {
        private readonly IProspectService prospectService;

        public bool Create(Prospect item)
        {
            return prospectService.Create(item);
        }

        public bool Update(Prospect item)
        {
            return prospectService.Update(item);
        }

        public bool Delete(int? id)
        {
            return id != null && prospectService.Delete(id);
        }

        public IEnumerable<Prospect> GetAll()
        {
            return prospectService.GetAll();
        }

        public Prospect Find(int id)
        {
            return prospectService.Find(id);
        }
    }
}
