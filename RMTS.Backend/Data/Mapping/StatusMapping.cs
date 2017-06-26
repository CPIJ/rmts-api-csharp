using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Mapping
{
	public class StatusMapping : EntityTypeConfiguration<Status>
	{
		internal StatusMapping()
		{
			Property(s => s.Content)
				.HasMaxLength(450)
				.IsRequired()
				.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
					new IndexAttribute("U_Name", 1) {IsUnique = true}));
		}
	}
}