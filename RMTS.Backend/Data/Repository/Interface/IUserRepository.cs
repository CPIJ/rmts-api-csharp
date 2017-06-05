using System.Collections.Generic;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Interface
{
    public interface IUserRepository
    {
	    bool Create(User user);
	    bool Update(User user);
	    bool Delete(int id);
        IEnumerable<User> GetAll();
        User Find(int id);
    }
}