using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class calibratorMap : EntityTypeConfiguration<calibrator>
    {
        public calibratorMap()
        {
            // Primary Key
            this.HasKey(t => t.calibratorId);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("calibrators");
            this.Property(t => t.calibratorId).HasColumnName("calibratorId");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.model_of_gauge_id).HasColumnName("model_of_gauge_id");
        }
    }
}
