using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Applications.Repositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables;

public static class TableExtensionServiceCollections
{
    public static IServiceCollection AddDataDbRepositories(this IServiceCollection services)
    {
        services.AddTableRepository<UserTable>();

        services.AddScoped(typeof(DataDbContext),
            sp =>
            {
                var options = sp.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<DataDbContext>>();
                return new DataDbContext(options);
            });

        services.AddTransient<IAuthRepository, AuthRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }

    private static void AddTableRepository<TTable>(this IServiceCollection services)
        where TTable : BaseTable
    {
        var logger = services.BuildServiceProvider().GetService<ILogger<WriteDbRepository<TTable>>>();
        services.AddTransient<IReadDbRepository<TTable>>(sp =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new ReadDbRepository<TTable>(context);
        });
        services.AddTransient<IWriteDbRepository<TTable>>(sp =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new WriteDbRepository<TTable>(context, logger);
        });
    }
}