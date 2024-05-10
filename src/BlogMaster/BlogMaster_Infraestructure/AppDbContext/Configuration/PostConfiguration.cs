using BlogMaster_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogMaster_Infraestructure.AppDbContext.Configuration {
    public class PostConfiguration : IEntityTypeConfiguration<Post> {
        public void Configure(EntityTypeBuilder<Post> builder) {
            builder.ToTable("POSTS");

            builder.HasKey(x => x.Id);

            builder.Property(p=>p.Title)
                .HasColumnName("TITLE")
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.PostDate)
                .HasColumnName("POSTDATE")
                .IsRequired();            
        }
    }
}
