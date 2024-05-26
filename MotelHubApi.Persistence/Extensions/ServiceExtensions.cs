using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

        var options = new DbContextOptions<MotelHubSqlServerDbContext>();
        var builder = new DbContextOptionsBuilder<MotelHubSqlServerDbContext>(options);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging(false);

        services.AddDbContext<MotelHubSqlServerDbContext>(options => {
            options.UseSqlServer(connectionString, sqlServerOptionsAction => {
                sqlServerOptionsAction.EnableRetryOnFailure();
            });

            options.EnableSensitiveDataLogging();
        });

    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient<IAreaRepository, AreaRepository>()
            .AddTransient<IRoomRepository, RoomRepository>()
            .AddTransient<IContractRepository, ContractRepository>()
            .AddTransient<IBillRepository, BillRepository>()
            .AddTransient<IPhotoRepository, PhotoRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IAppointmentRepository, AppointmentRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            ;
    }
}

