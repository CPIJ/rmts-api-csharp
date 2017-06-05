using System.Collections.Generic;
using System.Data;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
	public class ActionTypeService : IActionTypeService
	{
		private readonly IActionTypeRepository actionTypeRepository;

		public ActionTypeService(IActionTypeRepository actionTypeRepository)
		{
			this.actionTypeRepository = actionTypeRepository;
		}

		public bool Create(ActionType item)
		{
			return actionTypeRepository.Create(item);
		}

		public bool Update(ActionType item)
		{
			return actionTypeRepository.Update(item);
		}

		public bool Delete(int? id)
		{
			return id != null && actionTypeRepository.Delete(id.Value);
		}

		public IEnumerable<ActionType> GetAll()
		{
			return actionTypeRepository.GetAll();
		}

		public ActionType Find(int id)
		{
			return actionTypeRepository.Find(id);
		}
	}
}