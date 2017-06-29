using System;
using System.Linq;
using System.Web.Http;
using RMTS.API.Security;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using Action = RMTS.Backend.Models.Action;

namespace RMTS.API.Controllers
{
	[RoutePrefix("Action")]
    public class ActionController : BasicController<Action>
    {

		private static readonly IActionService ActionService = new ActionService(new EfActionRepository());

        public ActionController() : base(ActionService) { }

	    [HttpGet]
	    [Route("All/Sorted")]
	    public IHttpActionResult GetAllSorted()
	    {
		    return Ok(ActionService.GetAllSorted());
	    }

        [HttpGet]
        [Route("All/Prospect/{prospectId}")]
        public IHttpActionResult GetAllByProspect(int? prospectId)
        {
	        if (prospectId == null) return BadRequest("Invalid parameter");

	        return Ok(ActionService.GetAllByProspect(prospectId.Value));
        }

        [HttpGet]
        [Route("All/Unsorted/Prospect/{prospectId}")]
        public IHttpActionResult GetAllByProspectUnsorted(int? prospectId)
        {
	        if (prospectId == null) return BadRequest("Invalid parameter");

	        return Ok(ActionService.GetAllByProspectUnsorted(prospectId.Value));
        }

        [HttpGet]
        [Route("All/User/{userId}")]
        public IHttpActionResult GetAllByUser(int? userId)
        {
	        if (userId == null) return BadRequest("Invalid paramter");

	        return Ok(ActionService.GetAllByUser(userId.Value));
        }

	    [HttpGet]
	    [Route("All/Unsorted/User/{userId}")]
	    public IHttpActionResult GetAllByUserUnsorted(int? userId)
	    {
			if (userId == null) return BadRequest("Invalid paramter");

		    return Ok(ActionService.GetAllByUserUnsorted(userId.Value));
		}
    }
}
