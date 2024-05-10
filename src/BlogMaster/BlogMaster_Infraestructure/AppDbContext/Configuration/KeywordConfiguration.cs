using BlogMaster_Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogMaster_Infraestructure.AppDbContext.Configuration {
    public class KeywordConfiguration : IEntityTypeConfiguration<Keyword> {
        public void Configure(EntityTypeBuilder<Keyword> builder) {
            builder.ToTable("KEYWORDS");

            builder.HasKey(k => new { k.PostId, k.Word });

            builder.Property(k => k.PostId)
                .HasColumnName("POSTID")
                .IsRequired();

            /*builder.HasOne(k => k.Post)
                .WithMany(p => p.Keywords)
                .HasForeignKey(k => k.PostId);*/

            builder.Property(k => k.Word)
                .HasColumnName("WORD")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
