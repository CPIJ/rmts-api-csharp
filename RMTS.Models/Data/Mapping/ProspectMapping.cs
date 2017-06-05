using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Mapping
{
	public class ProspectMapping : EntityTypeConfiguration<Prospect>
	{
		internal ProspectMapping()
		{
			Property(p => p.EmailAddress)
			.HasMaxLength(450)
			.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
				new IndexAttribute("U_EmailAddress", 1) { IsUnique = true }));

			Property(p => p.Profession)
				.HasMaxLength(450)
				.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
					new IndexAttribute("U_Profession", 2) { IsUnique = true }));
		}
	}
}	