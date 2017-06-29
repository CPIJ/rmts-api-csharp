using System.Collections;
using System.Collections.Generic;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Interface
{
	public interface IActionService : IBasicService<Action>
	{
		SortedActions GetAllByProspect(int prospectId);
		IEnumerable<Action> GetAllByProspectUnsorted(int prospectId);
		SortedActions GetAllByUser(int userId);
		IEnumerable<Action> GetAllByUserUnsorted(int userId);
		SortedActions GetAllSorted();
	}
}