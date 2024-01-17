using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace MotelHubApi.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IAuthenticationService, AuthenticationService>()
                .AddTransient<ITokenService, TokenService>()
                ;
    }
}

