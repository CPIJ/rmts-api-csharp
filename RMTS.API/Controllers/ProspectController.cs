using System.Web.Http;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("Prospect")]
    public class ProspectController : BasicController<Prospect>
    {
	    private static readonly IProspectService ProspectService = new ProspectService(new EfProspectRepository());
        public ProspectController() : base(ProspectService) { }

    }
}
