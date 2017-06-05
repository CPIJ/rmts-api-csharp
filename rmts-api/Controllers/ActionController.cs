using System.Web.Http;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("Action")]
    public class ActionController : BasicController<Action>
    {
        // TODO: Add correct AcionService instead of null.
        public ActionController() : base(null) { }

        [HttpGet]
        [Route("All/Prospect/{prospectId}")]
        public IHttpActionResult GetAllByProspect(int prospectId)
        {
            return BadRequest("Endpoint not implemented");
        }

        [HttpGet]
        [Route("All/Unsorted/Prospect/{prospectId}")]
        public IHttpActionResult GetAllByProspectUnsorted(int prospectId)
        {
            return BadRequest("Endpoint not implemented");
        }

        [HttpGet]
        [Route("All/User/{userId}")]
        public IHttpActionResult GetAllByUser(int userId)
        {
            return BadRequest("Endpoint not implemented");
        }

        [HttpGet]
        [Route("All/Unsorted/User/{userId}")]
        public IHttpActionResult GetAllByUserUnsorted(int userId)
        {
            return BadRequest("Endpoint not implemented");
        }
    }
}
