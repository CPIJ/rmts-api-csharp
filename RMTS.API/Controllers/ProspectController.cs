using System.Web.Http;
using RMTS.Backend.Data.Service;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("Prospect")]
    public class ProspectController : BasicController<Prospect>
    {
        // TODO: Add correct ProspectService instead of null.
        public ProspectController() : base(null) { }

    }
}
