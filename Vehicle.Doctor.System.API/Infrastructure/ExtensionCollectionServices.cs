using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.Exceptions.Middleware;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Applications.Middleware;
using Vehicle.Doctor.System.API.Applications.Middleware.Logging;
using Vehicle.Doctor.System.API.Applications.Repositories;
using Vehicle.Doctor.System.API.Infrastructure.Swagger.CustomizeHeader;
using Vehicle.Doctor.System.API.Infrastructure.Swagger;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
#pragma warning disable S3267

namespace Vehicle.Doctor.System.API.Infrastructure;

public static class ExtensionCollectionServices
{
    private static IServiceCollection AddJwtAuth(this IServiceCollection services, ApplicationSetting applicationSetting)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = applicationSetting.Jwt.Audience,
                    ValidIssuer = applicationSetting.Jwt.Site,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(applicationSetting.Jwt.SigningKey)),
                    ValidateLifetime = false
                };
            });
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ApplicationSetting appSetting)
    {
        services.AddStackExchangeRedisCache(otp =>
        {
            otp.Configuration = appSetting.Redis.Url;
        });

        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        services.AddTransient<ITokenRepository, TokenRepository>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSqlServerDatabase<DataDbContext>()
            .AddDataDbRepositories()
            .AddJwtAuth(appSetting)
            .Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.All;
            });
        if (appSetting.Swagger.IsEnable)
        {
            services.AddSwagger<AuthorizationHeaderParameterOperationFilter>("Vehicle.Doctor.System.Api.xml");
        }
        return services;
    }

    public static WebApplication UseCustomSwagger(this WebApplication app)
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
        });

        _ = app.UseSwaggerUI(c =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }

            c.RoutePrefix = "swagger";
        });
        return app;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseErrorHandler()
            .UseMiddleware<AuthorizationRequestHandlerMiddleware>()
            .UseMiddleware<LogMiddleware>()
            .UseAllForwardedHeaders()
            .UseLogUserIdMiddleware();
        return app;
    }

    private static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
    private static IApplicationBuilder UseAllForwardedHeaders(this IApplicationBuilder builder)
    {
        return builder.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
    }

    private static void UseLogUserIdMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<LogUserIdMiddleware>();
    }


    /// <summary>
    /// https://stackoverflow.com/questions/29261734/add-filter-to-all-query-entity-framework
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="expression"></param>
    /// <typeparam name="TInterface"></typeparam>
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,
        Expression<Func<TInterface, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(e => typeof(TInterface).IsAssignableFrom(e.ClrType) && e.BaseType == null)
            .Select(e => e.ClrType);

        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newBody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);

            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newBody, newParam));
        }
    }
}