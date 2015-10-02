using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class certificateMap : EntityTypeConfiguration<certificate>
    {
        public certificateMap()
        {
            // Primary Key
            this.HasKey(t => t.certifacateId);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(50);

            this.Property(t => t.authorized_by)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("certificates");
            this.Property(t => t.certifacateId).HasColumnName("certifacateId");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.cost).HasColumnName("cost");
            this.Property(t => t.authorized_by).HasColumnName("authorized_by");
            this.Property(t => t.gauge_id).HasColumnName("gauge_id");

            // Relationships
            this.HasRequired(t => t.gauge)
                .WithMany(t => t.certificates)
                .HasForeignKey(d => d.gauge_id);

        }
    }
}
