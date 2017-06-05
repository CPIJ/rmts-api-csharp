using System.Collections.Generic;
using System.Linq;
using RMTS.Backend.Data.Repository.Implementations;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
    public class UserService : IUserService
    {
	    private readonly IUserRepository userRepository;

	    public UserService(IUserRepository userRepository)
	    {
		    this.userRepository = userRepository;
	    }

	    public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User Find(int id)
        {
            return userRepository.Find(id);
        }

        public User Login(Credentials credentials)
        {
            return GetAll()
                    .FirstOrDefault(u =>
                        u.Username == credentials.Username &&
                        u.Password == credentials.Password
                    );
        }

        public bool Create(User item)
        {
	        return userRepository.Create(item);
        }

        public bool Update(User item)
        {
	        return userRepository.Update(item);
        }

        public bool Delete(int? id)
        {
	        return id != null && userRepository.Delete(id.Value);
        }
    }
}