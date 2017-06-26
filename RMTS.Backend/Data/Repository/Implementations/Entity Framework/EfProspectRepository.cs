using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Implementations.Entity_Framework
{
	public class EfProspectRepository : IProspectRepository
	{
		public bool Create(Prospect item)
		{
			using (var context = new RmtsContext())
			{
				context.Statuses.Attach(item.Status);
				context.Prospects.Add(item);
				return context.SaveChanges() > -1;
			}
		}

		public bool Update(Prospect item)
		{
			using (var context = new RmtsContext())
			{
				var prospectToUpdate = context.Prospects.FirstOrDefault(p => p.Id == item.Id);
				var addressToUpdate = context.Addresses.FirstOrDefault(a => a.Id == item.Address.Id);
				var statusToUpdate = context.Statuses.FirstOrDefault(s => s.Id == item.Status.Id);
				var socialToUpdate = context.SocialLinks.FirstOrDefault(s => s.Id == item.SocialLinks.Id);

				if (addressToUpdate == null)
				{
					prospectToUpdate.Address = context.Addresses.Add(item.Address);
				}
				else
				{
					context.Entry(addressToUpdate).CurrentValues.SetValues(item.Address);
				}

				if (socialToUpdate == null)
				{
					prospectToUpdate.SocialLinks = context.SocialLinks.Add(item.SocialLinks);
				}
				else
				{
					context.Entry(socialToUpdate).CurrentValues.SetValues(item.SocialLinks);
				}

				context.Entry(statusToUpdate).CurrentValues.SetValues(item.Status);
				context.Entry(prospectToUpdate).CurrentValues.SetValues(item);

				return context.SaveChanges() > -1;
			}
		}

		public bool Delete(int? id)
		{
			using (var context = new RmtsContext())
			{
				var prospectToDelete = context.Prospects.FirstOrDefault(p => p.Id == id.Value);
				if (prospectToDelete == null) return false;

				context.Prospects.Remove(prospectToDelete);
				return context.SaveChanges() > -1;
			}
		}

		public IEnumerable<Prospect> GetAll()
		{
			using (var context = new RmtsContext())
			{
				return context.Prospects
					.Include(p => p.Address)
					.Include(p => p.SocialLinks)
					.Include(p => p.Status)
					.Include(p => p.Status.Prospects)
					.ToList();
			}
		}

		public Prospect Find(int id)
		{
			using (var context = new RmtsContext())
			{
				return context.Prospects.Where(p => p.Id == id)
					.Include(p => p.Address)
					.Include(p => p.SocialLinks)
					.Include(p => p.Status)
					.Include(p => p.Status.Prospects)
					.FirstOrDefault();
			}
		}
	}
}