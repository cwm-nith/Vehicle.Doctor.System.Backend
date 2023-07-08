using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vehicle.Doctor.System.API.Applications.Configurations;

namespace Vehicle.Doctor.System.API.Infrastructure.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly ApplicationSetting _appSettings;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, ApplicationSetting appSettings)
    {
        _provider = provider;
        _appSettings = appSettings;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo { Title = _appSettings.Swagger.Name, Version = description.ApiVersion.ToString() };
        return info;
    }
}