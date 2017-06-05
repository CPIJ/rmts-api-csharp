using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Interface
{
    public interface IUserService : BasicService<User>
    {
        User Login(Credentials credentials);
    }
}