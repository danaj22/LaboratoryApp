using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class calibrators_model_of_gaugesMap : EntityTypeConfiguration<calibrators_model_of_gauges>
    {
        public calibrators_model_of_gaugesMap()
        {
            // Primary Key
            this.HasKey(t => t.calibrator_modelId);

            // Properties
            // Table & Column Mappings
            this.ToTable("calibrators_model_of_gauges");
            this.Property(t => t.calibrator_modelId).HasColumnName("calibrator_modelId");
            this.Property(t => t.calibrator_id).HasColumnName("calibrator_id");
            this.Property(t => t.model_of_gaug_id).HasColumnName("model_of_gaug_id");

            // Relationships
            this.HasOptional(t => t.calibrator)
                .WithMany(t => t.calibrators_model_of_gauges)
                .HasForeignKey(d => d.calibrator_id);
            this.HasOptional(t => t.model_of_gauges)
                .WithMany(t => t.calibrators_model_of_gauges)
                .HasForeignKey(d => d.model_of_gaug_id);

        }
    }
}
