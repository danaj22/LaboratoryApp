using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class gaugeMap : EntityTypeConfiguration<gauge>
    {
        public gaugeMap()
        {
            // Primary Key
            this.HasKey(t => t.gaugeId);

            // Properties
            this.Property(t => t.serial_number)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gauges");
            this.Property(t => t.gaugeId).HasColumnName("gaugeId");
            this.Property(t => t.serial_number).HasColumnName("serial_number");
            this.Property(t => t.client_id).HasColumnName("client_id");
            this.Property(t => t.office_id).HasColumnName("office_id");
            this.Property(t => t.model_of_gauge_id).HasColumnName("model_of_gauge_id");

            // Relationships
            this.HasRequired(t => t.client)
                .WithMany(t => t.gauges)
                .HasForeignKey(d => d.client_id);
            this.HasRequired(t => t.model_of_gauges)
                .WithMany(t => t.gauges)
                .HasForeignKey(d => d.model_of_gauge_id);
            this.HasOptional(t => t.office)
                .WithMany(t => t.gauges)
                .HasForeignKey(d => d.office_id);

        }
    }
}
