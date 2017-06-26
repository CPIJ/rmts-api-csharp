using System.Collections.Generic;
using System.Linq;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Implementations.Entity_Framework
{
	public class EfUserRepository : IUserRepository
	{

		public bool Create(User user)
		{
			using (var context = new RmtsContext())
			{
				context.Users.Add(user);
				return context.SaveChanges() > -1;
			}
		}

		public bool Update(User user)
		{
			using (var context = new RmtsContext())
			{
				var foundUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
				if (foundUser == null) return false;

				context.Entry(foundUser).CurrentValues.SetValues(user);
				return context.SaveChanges() > -1;
			}
		}

		public bool Delete(int id)
		{
			using (var context = new RmtsContext())
			{
				var userToDelete = context.Users.FirstOrDefault(u => u.Id == id);
				if (userToDelete == null) return false;

				context.Users.Remove(userToDelete);
				return context.SaveChanges() > -1;
			}
		}

		public IEnumerable<User> GetAll()
		{
			using (var context = new RmtsContext())
			{
				return context.Users.ToList();
			}
		}

		public User Find(int id)
		{
			using (var context = new RmtsContext())
			{
				return context.Users.Find(id);
			}
		}
	}
}