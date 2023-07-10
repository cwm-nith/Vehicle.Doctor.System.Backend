using Vehicle.Doctor.System.API.Applications.Repositories.Posts;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

public static class Extensions
{
    public static void AddPostRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<ILikeRepository, LikeRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
    }
}