using System.Collections.Generic;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Repository.Interface
{
	public interface IProspectRepository
	{
		bool Create(Prospect item);
		bool Update(Prospect item);
		bool Delete(int? id);
		IEnumerable<Prospect> GetAll();
		Prospect Find(int id);
	}
}