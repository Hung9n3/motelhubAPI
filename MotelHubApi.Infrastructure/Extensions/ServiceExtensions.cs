using System;
using Microsoft.Extensions.DependencyInjection;

namespace MotelHubApi.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IEmailService, EmailService>();
    }
}

