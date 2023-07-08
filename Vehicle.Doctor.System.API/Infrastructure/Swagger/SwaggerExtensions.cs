using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vehicle.Doctor.System.API.Infrastructure.Options;

namespace Vehicle.Doctor.System.API.Infrastructure.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger<THeader>(this IServiceCollection services, string docFileName) where THeader : IOperationFilter
    {
        services.ConfigureOptions<ConfigureSwaggerOptions>();
        services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            })
            .AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.ExampleFilters();
            c.OperationFilter<THeader>();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } },
                    new List<string>()
                }
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, docFileName);
            c.IncludeXmlComments(filePath);
            c.OperationFilter<
                AppendAuthorizeToSummaryOperationFilter>();
        });
        services.AddSwaggerExamplesFromAssemblyOf();
        return services;
    }
}