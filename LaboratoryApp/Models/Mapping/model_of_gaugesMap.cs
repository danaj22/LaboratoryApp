using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class model_of_gaugesMap : EntityTypeConfiguration<model_of_gauges>
    {
        public model_of_gaugesMap()
        {
            // Primary Key
            this.HasKey(t => t.model_of_gaugeId);

            // Properties
            this.Property(t => t.manufacturer_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.model)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("model_of_gauges");
            this.Property(t => t.model_of_gaugeId).HasColumnName("model_of_gaugeId");
            this.Property(t => t.manufacturer_name).HasColumnName("manufacturer_name");
            this.Property(t => t.model).HasColumnName("model");
            this.Property(t => t.usage_id).HasColumnName("usage_id");
            this.Property(t => t.type_id).HasColumnName("type_id");

            // Relationships
            this.HasRequired(t => t.type)
                .WithMany(t => t.model_of_gauges)
                .HasForeignKey(d => d.type_id);
            this.HasRequired(t => t.usage)
                .WithMany(t => t.model_of_gauges)
                .HasForeignKey(d => d.usage_id);

        }
    }
}
