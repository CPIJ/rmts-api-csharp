using System.Collections.Generic;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
	public class ActionService : IActionService
	{
		private readonly IActionRepository actionRepository;

		public ActionService(IActionRepository actionRepository)
		{
			this.actionRepository = actionRepository;
		}

		public bool Create(Action item)
		{
			return actionRepository.Create(item);
		}

		public bool Update(Action item)
		{
			return actionRepository.Update(item);
		}

		public bool Delete(int? id)
		{
			return id != null && actionRepository.Delete(id.Value);
		}

		public IEnumerable<Action> GetAll()
		{
			return actionRepository.GetAll();
		}

		public Action Find(int id)
		{
			return actionRepository.Find(id);
		}

		public SortedActions GetAllByProspect(int prospectId)
		{
			return actionRepository.GetAllByProspect(prospectId);
		}

		public IEnumerable<Action> GetAllByProspectUnsorted(int prospectId)
		{
			return actionRepository.GetAllByProspectUnsorted(prospectId);
		}

		public SortedActions GetAllByUser(int userId)
		{
			return actionRepository.GetAllByUser(userId);
		}

		public IEnumerable<Action> GetAllByUserUnsorted(int userId)
		{
			return actionRepository.GetAllByUserUnsorted(userId);
		}
	}
}