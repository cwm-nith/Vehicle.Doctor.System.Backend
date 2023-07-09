using Vehicle.Doctor.System.API.Applications.Repositories.Garages;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Garages;

public static class Extensions
{
    public static void AddGarageRepositories(this IServiceCollection services)
    {
        services.AddTransient<IGarageRepository, GarageRepository>();
        services.AddTransient<IGarageContactRepository, GarageContactRepository>();
        services.AddTransient<IGarageSocialLinkRepository, GarageSocialLinkRepository>();
    }
}