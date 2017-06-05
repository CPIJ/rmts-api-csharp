using System.Web.Http;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("Status")]
    public class StatusController : BasicController<Status>
    {
        // TODO: Add correct StatusService instead of null.
        public StatusController() : base(null) { }

    }
}
