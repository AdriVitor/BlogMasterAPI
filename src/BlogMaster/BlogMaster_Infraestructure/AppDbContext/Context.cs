using BlogMaster_Domain.Entities;
using BlogMaster_Domain.ValueObjects;
using BlogMaster_Infraestructure.AppDbContext.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlogMaster_Infraestructure.AppDbContext {
    public class Context : DbContext {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Keyword> Keyword { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new KeywordConfiguration());
        }
    }
}
