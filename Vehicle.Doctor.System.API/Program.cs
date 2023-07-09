using NLog;
using Vehicle.Doctor.System.API.Applications;
using Vehicle.Doctor.System.API.Applications.Configurations;
using Vehicle.Doctor.System.API.Infrastructure;

var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
logger.Info("Application is started");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers().AddNewtonsoftJson();

    var appSetting = new ApplicationSetting();
    builder.Configuration.GetSection("AppSetting").Bind(appSetting);
    builder.Services.AddSingleton(appSetting);

    builder.Services
        .AddApplicationService()
        .AddInfrastructure(appSetting);

    var app = builder.Build();

    var settings = app.Services.GetService<ApplicationSetting>();
    if (settings?.Swagger.IsEnable ?? false) app.UseCustomSwagger();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseInfrastructure();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
