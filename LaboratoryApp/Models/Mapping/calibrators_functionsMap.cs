using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    class calibrators_functionsMap : EntityTypeConfiguration<calibrators_functions>
    {
        public calibrators_functionsMap()
        {
            // Primary Key
            this.HasKey(t => t.calibrator_functionId);

            // Properties
            // Table & Column Mappings
            this.ToTable("calibrators_functions");
            this.Property(t => t.calibrator_functionId).HasColumnName("calibrator_functionId");
            this.Property(t => t.calibrator_id).HasColumnName("calibrator_id");
            this.Property(t => t.function_id).HasColumnName("function_id");

            // Relationships
            this.HasOptional(t => t.calibrator)
                .WithMany(t => t.calibrators_functions)
                .HasForeignKey(d => d.calibrator_id);
            this.HasOptional(t => t.function)
                .WithMany(t => t.calibrators_functions)
                .HasForeignKey(d => d.function_id);

        }
    }
}
