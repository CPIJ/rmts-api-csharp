using System.Web.Http;
using RMTS.Backend.Data.Repository.Implementations;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.API.Controllers
{
    [RoutePrefix("User")]
    public class UserController : BasicController<User>
    {
        private static readonly IUserService UserService = new UserService(new EfUserRepository());

        // This constructor is to setup the CRUD abillities for users.
        public UserController() : base(UserService) { }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(Credentials credentials)
        {
            if (credentials == null) return BadRequest("No credentials provided.");

            return Ok(UserService.Login(credentials));
        }
    }
}
