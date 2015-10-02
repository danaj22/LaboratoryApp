using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class officeMap : EntityTypeConfiguration<office>
    {
        public officeMap()
        {
            // Primary Key
            this.HasKey(t => t.officeId);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.adress)
                .HasMaxLength(150);

            this.Property(t => t.contact_person_name)
                .HasMaxLength(70);

            this.Property(t => t.mail)
                .HasMaxLength(70);

            this.Property(t => t.tel)
                .HasMaxLength(15);

            this.Property(t => t.is_default)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("offices");
            this.Property(t => t.officeId).HasColumnName("officeId");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.contact_person_name).HasColumnName("contact_person_name");
            this.Property(t => t.mail).HasColumnName("mail");
            this.Property(t => t.tel).HasColumnName("tel");
            this.Property(t => t.is_default).HasColumnName("is_default");
            this.Property(t => t.client_id).HasColumnName("client_id");

            // Relationships
            this.HasRequired(t => t.client)
                .WithMany(t => t.offices)
                .HasForeignKey(d => d.client_id);

        }
    }
}
