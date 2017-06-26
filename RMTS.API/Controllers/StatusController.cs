using System.Web.Http;
using RMTS.API.Security;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
	[BasicAuthentication]
	[RoutePrefix("Status")]
    public class StatusController : BasicController<Status>
    {
        private static readonly IStatusService StatusService = new StatusService(new EfStatusRepository());

        public StatusController() : base(StatusService) { }

    }
}
