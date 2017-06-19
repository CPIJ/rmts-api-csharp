using System.Collections.Generic;
using RMTS.Backend.Data.Repository.Interface;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Service.Implementation
{
	public class ProspectService : IProspectService
	{
		private readonly IProspectRepository prospectRepository;

		public ProspectService(IProspectRepository prospectRepository)
		{
			this.prospectRepository = prospectRepository;
		}

		public bool Create(Prospect item)
		{
			return prospectRepository.Create(item);
		}

		public bool Update(Prospect item)
		{
			return prospectRepository.Update(item);
		}

		public bool Delete(int? id)
		{
			return prospectRepository.Delete(id);
		}

		public IEnumerable<Prospect> GetAll()
		{
			return prospectRepository.GetAll();
		}

		public Prospect Find(int id)
		{
			return prospectRepository.Find(id);
		}
	}
}