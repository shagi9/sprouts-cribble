using Microsoft.EntityFrameworkCore;
using SproutScribble.Biz.Posts;

namespace SproutScribble.Biz.DatabaseContext
{
    public class SproutScribbleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql("Host=localhost; Database = sprout-scribble; Username=postgres; Password=password");
        }

        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
        }
    }
}
