using System.Reflection;

namespace Vehicle.Doctor.System.API.Applications;

public static class ApplicationExtensionService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddHttpContextAccessor();
        return services;
    }
}