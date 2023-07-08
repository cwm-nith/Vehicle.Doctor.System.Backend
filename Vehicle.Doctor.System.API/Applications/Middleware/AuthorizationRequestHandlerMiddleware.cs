﻿using Vehicle.Doctor.System.API.Applications.Exceptions.Middleware;
using Vehicle.Doctor.System.API.Applications.Exceptions;

namespace Vehicle.Doctor.System.API.Applications.Middleware;

public sealed class AuthorizationRequestHandlerMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    public AuthorizationRequestHandlerMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task Invoke(HttpContext context)
    {
        var path = context.Request.Path.Value;
        if (path != null && path.Contains("api/webhook/"))
        {
            return _next(context);
        }

        var clientHeader = context.Request.Headers["X-Client"].ToString();
        AppDataSetting.ClientHeaders.TryGetValue(clientHeader, out var client);
        if (string.IsNullOrEmpty(client))
        {
            throw new UnAuthorizedRequestException();
        }

        _logger.LogInformation("Requested Client {@Client}", client);
        return _next(context);
    }
}