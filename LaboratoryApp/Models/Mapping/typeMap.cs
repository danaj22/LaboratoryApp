using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class typeMap : EntityTypeConfiguration<type>
    {
        public typeMap()
        {
            // Primary Key
            this.HasKey(t => t.typeId);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("types");
            this.Property(t => t.typeId).HasColumnName("typeId");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
