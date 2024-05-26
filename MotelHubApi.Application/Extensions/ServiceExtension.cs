using System.Reflection;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace MotelHubApi;

public static class ServiceExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddRepositoryContext();
    }

    private static void AddRepositoryContext(this IServiceCollection services)
    {
        services.AddTransient<RepositoryContext>();
    }
}

