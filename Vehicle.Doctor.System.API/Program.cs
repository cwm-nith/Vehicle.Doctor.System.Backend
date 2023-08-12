using NLog;
using System.Net.Mime;
using Vehicle.Doctor.System.API.Applications;
using Vehicle.Doctor.System.API.Applications.Configurations;
using Vehicle.Doctor.System.API.Applications.Middleware.CustomValidationResult;
using Vehicle.Doctor.System.API.Infrastructure;

var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
logger.Info("Application is started");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var result = new ValidationFailedResult(context.ModelState);
                result.ContentTypes.Add(MediaTypeNames.Application.Json);

                return result;
            };
        }).AddNewtonsoftJson();

    var appSetting = new ApplicationSetting();
    builder.Configuration.GetSection("AppSetting").Bind(appSetting);
    builder.Services.AddSingleton(appSetting);

    builder.Services
        .AddApplicationService()
        .AddInfrastructure(appSetting);

    var app = builder.Build();
    if (appSetting?.Swagger.IsEnable ?? false) app.UseCustomSwagger();
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
