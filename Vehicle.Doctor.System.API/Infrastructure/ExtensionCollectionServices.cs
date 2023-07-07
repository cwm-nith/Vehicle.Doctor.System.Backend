using Vehicle.Doctor.System.API.Applications.Configurations;

namespace Vehicle.Doctor.System.API.Infrastructure;

public static class ExtensionCollectionServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ApplicationSetting appSetting)
    {
        services.AddStackExchangeRedisCache(otp =>
        {
            otp.Configuration = appSetting.Redis.Url;
        });
        return services;
    }
}