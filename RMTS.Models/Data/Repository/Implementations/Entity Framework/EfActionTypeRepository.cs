using System.Collections.Generic;
using System.Linq;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Implementations.Entity_Framework
{
	public class EfActionTypeRepository : IActionTypeRepository
	{
		public bool Create(ActionType actionType)
		{
			using (var context = new RmtsContext())
			{
				context.ActionTypes.Add(actionType);
				return context.SaveChanges() > 0;
			}
		}

		public bool Update(ActionType actionType)
		{
			throw new System.NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<ActionType> GetAll()
		{
			using (var context = new RmtsContext())
			{
				return context.ActionTypes.ToList();
			}
		}

		public ActionType Find(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}