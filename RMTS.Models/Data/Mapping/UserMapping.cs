using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Mapping
{
	public class UserMapping : EntityTypeConfiguration<User>

	{
		internal UserMapping()
		{
			Property(u => u.Username)
			.HasMaxLength(450)
			.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
				new IndexAttribute("U_Username", 1) { IsUnique = true }));
		}
	}
}