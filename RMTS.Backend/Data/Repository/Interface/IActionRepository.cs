using System.Collections.Generic;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Interface
{
	public interface IActionRepository
	{
		bool Create(Action action);
		bool Update(Action action);
		bool Delete(int id);
		IEnumerable<Action> GetAll();
		Action Find(int id);
	}
}