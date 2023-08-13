namespace Vehicle.Doctor.System.API.Applications.Helpers;

public static class HelperExtensions
{
    public static void AddHelper(this IServiceCollection services)
    {
        services.AddTransient<CacheHelper>();
    }
}