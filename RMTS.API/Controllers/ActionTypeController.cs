using System.Web.Http;
using RMTS.API.Security;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
	[BasicAuthentication]
	[RoutePrefix("ActionType")]
    public class ActionTypeController : BasicController<ActionType>
    {
		private static readonly IActionTypeService ActionTypeService = new ActionTypeService(new EfActionTypeRepository());

        public ActionTypeController() : base(ActionTypeService) { }
    }
}
