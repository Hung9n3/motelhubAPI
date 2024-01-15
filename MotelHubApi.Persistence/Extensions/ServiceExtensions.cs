using System;
using Microsoft.Extensions.DependencyInjection;

namespace MotelHubApi.Persistence;

public static class ServiceExtensions
{
    private static void AddRepositories(this IServiceCollection services)
    {
        services
            //.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient<IRoomRepository, RoomRepository>()
            ;
    }
}

