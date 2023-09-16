using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Applications.Repositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables;

public static class TableExtensionServiceCollections
{
    public static IServiceCollection AddDataDbRepositories(this IServiceCollection services)
    {
        services.AddTableRepository<UserTable>();
        services.AddTableRepository<GarageTable>();
        services.AddTableRepository<GarageSocialLinkTable>();

        services.AddTableRepository<PostTable>();
        services.AddTableRepository<LikeTable>();
        services.AddTableRepository<CommentTable>();

        services.AddScoped(typeof(DataDbContext),
            sp =>
            {
                var options = sp.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<DataDbContext>>();
                return new DataDbContext(options);
            });

        services.AddTransient<IAuthRepository, AuthRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddGarageRepositories();
        services.AddPostRepositories();
        return services;
    }

    private static void AddTableRepository<TTable>(this IServiceCollection services)
        where TTable : BaseTable
    {
        var logger = services.BuildServiceProvider().GetService<ILogger<WriteDbRepository<TTable>>>();
        services.AddTransient<IReadDbRepository<TTable>>(_ =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new ReadDbRepository<TTable>(context);
        });
        services.AddTransient<IWriteDbRepository<TTable>>(_ =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new WriteDbRepository<TTable>(context, logger);
        });
    }
}