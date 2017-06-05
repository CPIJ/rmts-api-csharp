﻿using System.Web.Http;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("ActionType")]
    public class ActionTypeController : BasicController<ActionType>
    {
		private static readonly IActionTypeService ActionTypeService = new ActionTypeService(new EfActionTypeRepository());

        // TODO: Add correct ActionTypeService instead of null.
        public ActionTypeController() : base(ActionTypeService) { }
    }
}
