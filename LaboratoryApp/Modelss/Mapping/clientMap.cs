using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LaboratoryApp.Models.Mapping
{
    public class clientMap : EntityTypeConfiguration<client>
    {
        public clientMap()
        {
            // Primary Key
            this.HasKey(t => t.clientId);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.adress)
                .HasMaxLength(150);

            this.Property(t => t.contact_person_name)
                .HasMaxLength(70);

            this.Property(t => t.mail)
                .HasMaxLength(400);

            this.Property(t => t.tel)
                .HasMaxLength(15);

            this.Property(t => t.NIP)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.comments)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("clients");
            this.Property(t => t.clientId).HasColumnName("clientId");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.contact_person_name).HasColumnName("contact_person_name");
            this.Property(t => t.mail).HasColumnName("mail");
            this.Property(t => t.tel).HasColumnName("tel");
            this.Property(t => t.NIP).HasColumnName("NIP");
            this.Property(t => t.comments).HasColumnName("comments");
        }
    }
}
