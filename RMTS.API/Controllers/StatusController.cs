using System.Web.Http;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("Status")]
    public class StatusController : BasicController<Status>
    {
        private static readonly IStatusService StatusService = new StatusService(new EfStatusRepository());

        public StatusController() : base(StatusService) { }

    }
}
