using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data.Mapping
{
	public class ActionTypeMapping : EntityTypeConfiguration<ActionType>
	{
		internal ActionTypeMapping()
		{
			Property(a => a.Content)
				.HasMaxLength(450)
				.IsRequired()
				.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
					new IndexAttribute("U_Content", 1) { IsUnique = true }));
		}
	}
}