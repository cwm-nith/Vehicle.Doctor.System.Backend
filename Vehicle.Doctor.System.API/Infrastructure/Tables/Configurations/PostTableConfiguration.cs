using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Configurations;

public static class PostTableConfiguration
{
    public static ModelBuilder AddPostTableRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostTable>()
            .HasMany(i => i.Comments)
            .WithOne(i => i.Post)
            .HasForeignKey(i => i.PostId);
        modelBuilder.Entity<PostTable>()
            .HasMany(i => i.Likes)
            .WithOne(i => i.Post)
            .HasForeignKey(i => i.PostId);

        modelBuilder.Entity<LikeTable>()
            .HasOne(i => i.Post)
            .WithMany(i => i.Likes)
            .HasForeignKey(i => i.PostId);

        modelBuilder.Entity<CommentTable>()
            .HasOne(i => i.Post)
            .WithMany(i => i.Comments)
            .HasForeignKey(i => i.PostId);

        return modelBuilder;
    }
}