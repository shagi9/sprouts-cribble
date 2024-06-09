using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SproutScribble.Biz.Posts
{
    internal class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(x => x.PostId);
            builder.Property(x => x.Title).IsRequired();

            //seed data
            PostEntity[] postsEntities =
            [
                new() { PostId = 1, Title = "Post 1" },
                new() { PostId = 2, Title = "Post 2" },
                new() { PostId = 3, Title = "Post 3" }
            ];

            builder.HasData(postsEntities);
        }
    }
}
