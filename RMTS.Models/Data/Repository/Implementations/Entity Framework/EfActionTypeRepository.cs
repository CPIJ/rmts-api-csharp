using System;
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
			using (var context = new RmtsContext())
			{
				var at = context.ActionTypes.FirstOrDefault(a => a.Id == actionType.Id);
				if (at == null) return false;

				context.Entry(at).CurrentValues.SetValues(actionType);
				return context.SaveChanges() > 0;
			}
		}

		public bool Delete(int id)
		{
			using (var context = new RmtsContext())
			{
				var at = context.ActionTypes.FirstOrDefault(a => a.Id == id);
				if (at == null) return false;

				context.ActionTypes.Remove(at);
				return context.SaveChanges() > 0;
			}
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
			using (var context = new RmtsContext())
			{
				return context.ActionTypes.Find(id);
			}
		}
	}
}