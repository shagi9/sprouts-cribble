using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SproutScribble.Biz.Posts;
using SproutScribble.Biz.Users;

namespace SproutScribble.Biz.DatabaseContext
{
    public class SproutScribbleDbContext(DbContextOptions<SproutScribbleDbContext> options) : IdentityDbContext<UserEntity>(options)
    {
        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
        }
    }
}
