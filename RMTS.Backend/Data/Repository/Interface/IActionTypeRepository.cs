using System.Collections;
using System.Collections.Generic;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Interface
{
	public interface IActionTypeRepository
	{
		bool Create(ActionType actionType);
		bool Update(ActionType actionType);
		bool Delete(int id);
		IEnumerable<ActionType> GetAll();
		ActionType Find(int id);
	}
}