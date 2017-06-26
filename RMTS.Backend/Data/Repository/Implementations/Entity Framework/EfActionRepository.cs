using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Models;
using Action = RMTS.Backend.Models.Action;

namespace RMTS.Backend.Data.Repository.Implementations.Entity_Framework
{
	public class EfActionRepository : IActionRepository
	{
		public bool Create(Action action)
		{
			using (var context = new RmtsContext())
			{
				context.ActionTypes.Attach(action.ActionType);
				context.Statuses.Attach(action.Prospect.Status);
				context.Prospects.Attach(action.Prospect);
				context.Users.Attach(action.User);
				context.Actions.Add(action);
				return context.SaveChanges() > 0;
			}
		}

		public bool Update(Action action)
		{
			using (var context = new RmtsContext())
			{
				var foundAction = context.Actions.FirstOrDefault(a => a.Id == action.Id);
				if (foundAction == null) return false;

				context.Entry(foundAction).CurrentValues.SetValues(action);
				return context.SaveChanges() > 0;
			}
		}

		public bool Delete(int id)
		{
			using (var context = new RmtsContext())
			{
				var foundAction = context.Actions.FirstOrDefault(a => a.Id == id);
				if (foundAction == null) return false;

				context.Actions.Remove(foundAction);
				return context.SaveChanges() > 0;
			}
		}

		public IEnumerable<Action> GetAll()
		{
			using (var context = new RmtsContext())
			{
				// Include zorgt ervoor dat de properties megenomen worden.
				// Dit komt door het lazy loaden, als include er niet staat zijn de properties null.
				// Misschien een andere oplossing zoeken, iedere include voert namelijk een extra query uit.
				return context.Actions
					.Include(a => a.ActionType)
					.Include(a => a.User)
					.Include(a => a.Prospect)
					.Include(a => a.Prospect.Status.Prospects)
					.ToList();
			}
		}

		public Action Find(int id)
		{
			using (var context = new RmtsContext())
			{
				return context.Actions
					.Include(a => a.ActionType)
					.Include(a => a.User)
					.Include(a => a.Prospect)
					.Include(a => a.Prospect.Status.Prospects)
					.FirstOrDefault(a => a.Id == id);

			}
		}

		public SortedActions GetAllByProspect(int prospectId)
		{
			using (var context = new RmtsContext())
			{
				return SortedActions.FromList(
					context.Actions
						.Where(a => a.Prospect.Id == prospectId)
						.Include(a => a.ActionType)
						.Include(a => a.User)
						.Include(a => a.Prospect)
						.Include(a => a.Prospect.Status.Prospects)
						.ToList()
				);
			}
		}

		public IEnumerable<Action> GetAllByProspectUnsorted(int prospectId)
		{
			using (var context = new RmtsContext())
			{
				return context.Actions
					.Where(a => a.Prospect.Id == prospectId)
					.Include(a => a.ActionType)
					.Include(a => a.User)
					.Include(a => a.Prospect)
					.Include(a => a.Prospect.Status.Prospects)
					.ToList();
			}
		}

		public SortedActions GetAllByUser(int userId)
		{
			using (var context = new RmtsContext())
			{
				return SortedActions.FromList(
					context.Actions
						.Where(a => a.User.Id == userId)
						.Include(a => a.ActionType)
						.Include(a => a.User)
						.Include(a => a.Prospect)
						.Include(a => a.Prospect.Status.Prospects)
						.ToList()
				);
			}
		}

		public IEnumerable<Action> GetAllByUserUnsorted(int userId)
		{
			using (var context = new RmtsContext())
			{
				return context.Actions
					.Where(a => a.User.Id == userId)
					.Include(a => a.ActionType)
					.Include(a => a.User)
					.Include(a => a.Prospect)
					.Include(a => a.Prospect.Status.Prospects)
					.ToList();
			}
		}
	}
}