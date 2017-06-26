using System.Data.Entity.ModelConfiguration;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Mapping
{
	public class ActionMapping : EntityTypeConfiguration<Action>
	{
		internal ActionMapping()
		{
			Property(a => a.Location).IsRequired();

			HasRequired(a => a.ActionType)
				.WithMany(a => a.Actions)
				.HasForeignKey(a => a.ActionTypeId);
		}
	}
}