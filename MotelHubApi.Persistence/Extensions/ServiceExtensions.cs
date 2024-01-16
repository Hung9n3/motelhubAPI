using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MotelHubApi.Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration, string connectionStringKey = "LocalConnection")
    {
        services.AddDbContext(configuration, connectionStringKey);
        services.AddRepositories();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration, string connectionStringKey) 
    {
        var connectionString = configuration.GetConnectionString(connectionStringKey);

        services.AddDbContext<MotelHubSqlServerDbContext>(options =>
           options.UseSqlServer(connectionString,
               builder => builder.MigrationsAssembly(typeof(MotelHubSqlServerDbContext).Assembly.FullName)), ServiceLifetime.Scoped);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient<IAreaRepository, AreaRepository>()
            .AddTransient<IRoomRepository, RoomRepository>()
            .AddTransient<IMeterReadingRepository, MeterReadingRepository>()
            .AddTransient<IMeterReadingPriceRepository, MeterReadingPriceRepository>()
            .AddTransient<IContractRepository, ContractRepository>()
            .AddTransient<IBillRepository, BillRepository>()
            .AddTransient<IPhotoRepository, PhotoRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            ;
    }
}

