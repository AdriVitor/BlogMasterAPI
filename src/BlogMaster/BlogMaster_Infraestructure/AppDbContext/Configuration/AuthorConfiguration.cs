using BlogMaster_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BlogMaster_Infraestructure.AppDbContext.Configuration {
    public class AuthorConfiguration : IEntityTypeConfiguration<Author> {
        public void Configure(EntityTypeBuilder<Author> builder) {
            builder.ToTable("AUTHORS");

            builder.HasKey(x => x.Id);

            builder.Property(a=>a.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasColumnName("PASSWORD")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(a => a.DateOfBirth)
                .HasColumnName("DATEOFBIRTH")
                .IsRequired();
        }
    }
}
