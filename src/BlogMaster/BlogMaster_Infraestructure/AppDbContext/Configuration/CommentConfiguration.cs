using BlogMaster_Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogMaster_Infraestructure.AppDbContext.Configuration {
    public class CommentConfiguration : IEntityTypeConfiguration<Comment> {
        public void Configure(EntityTypeBuilder<Comment> builder) {
            builder.ToTable("COMMENTS");

            builder.HasKey(c=> new {c.PostId, c.AuthorId, c.DateOfPosting});

            builder.Property(c => c.PostId)
                .HasColumnName("POSTID")
                .IsRequired();

            builder.Property(c => c.AuthorId)
                .HasColumnName("AUTHORID")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired();

            builder.Property(c => c.DateOfPosting)
                .HasColumnName("DATEOFPOSTING")
                .IsRequired();

            /*builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);*/
        }
    }
}
