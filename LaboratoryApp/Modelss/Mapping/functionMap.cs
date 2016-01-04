using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class functionMap : EntityTypeConfiguration<function>
    {
        public functionMap()
        {
            // Primary Key
            this.HasKey(t => t.functionId);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("functions");
            this.Property(t => t.functionId).HasColumnName("functionId");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
