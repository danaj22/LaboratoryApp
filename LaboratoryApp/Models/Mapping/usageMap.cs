using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class usageMap : EntityTypeConfiguration<usage>
    {
        public usageMap()
        {
            // Primary Key
            this.HasKey(t => t.usageId);

            // Properties
            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("usages");
            this.Property(t => t.usageId).HasColumnName("usageId");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
