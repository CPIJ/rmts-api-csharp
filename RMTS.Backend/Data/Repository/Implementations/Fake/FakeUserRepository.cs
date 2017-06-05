using System.Collections.Generic;
using System.Linq;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Implementations.Fake
{
    public class FakeUserRepository : IUserRepository
    {

        private readonly IEnumerable<User> users = new List<User>
        {
                new User("Alex Otten", "a.otten", "test1234", true),
                new User("Casper Pijnenburg", "c.pijnenburg", "test1234", false),
                new User("Bas van Wijk", "b.vanwijk", "test1234", true),
        };

	    public bool Create(User user)
	    {
		    return user != null;
	    }

	    public bool Update(User user)
	    {
			return user != null;
		}

	    public bool Delete(int id)
	    {
			return id != null;
		}

	    public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User Find(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }
    }
}