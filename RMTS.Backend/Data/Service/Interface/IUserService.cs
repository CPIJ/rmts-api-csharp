using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Interface
{
    public interface IUserService : IBasicService<User>
    {
        User Login(Credentials credentials);
    }
}