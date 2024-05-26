using System;
using Elastic.Clients.Elasticsearch;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace MotelHubApi.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        //services.AddElasticsearch(configuration);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IAuthenticationService, AuthenticationService>()
                .AddTransient<ITokenService, TokenService>()
                //.AddTransient<IElasticsearchService, ElasticsearchService>()
                ;
    }

    private static void AddLogics(this IServiceCollection services)
    {
        services
            .AddTransient<IAreaLogic, AreaLogic>()
            .AddTransient<IRoomLogic, RoomLogic>()
            .AddTransient<IContractLogic, ContractLogic>()
            .AddTransient<IBillLogic, BillLogic>()
            .AddTransient<IPhotoLogic, PhotoLogic>()
            .AddTransient<IUserLogic, UserLogic>()
            .AddTransient<IAppointmentLogic, AppointmentLogic>()
            .AddTransient<IRoleLogic, RoleLogic>()
            ;
    }

    private static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            services.Configure<ElasticsearchConfig>(configuration.GetSection("ElasticsearchConfig"));
            var elasticsearchConfig = configuration.GetSection(nameof(ElasticsearchConfig)).Get<ElasticsearchConfig>();
            var connectionSettings = new ConnectionSettings(new Uri(elasticsearchConfig!.Url))
                            .PrettyJson()
                            .CertificateFingerprint(elasticsearchConfig.Certificate)
                            .BasicAuthentication(elasticsearchConfig.Username, elasticsearchConfig.Password)
                            .DefaultIndex(elasticsearchConfig?.DefaultIndex)
                            .EnableApiVersioningHeader()
                            .AddDefaultMappings()
                            ;

            var client = new ElasticClient(connectionSettings);

            services.AddSingleton<IElasticClient>(client);

            client.CreateIndex<Room>(elasticsearchConfig!.DefaultIndex);
        }
        catch (Exception)
        {
            return;
        }
    }

    private static ConnectionSettings AddDefaultMappings(this ConnectionSettings settings)
    {
       return settings.DefaultMappingFor<Room>(r => r
       .Ignore(x => x.Photos).Ignore(x => x.Appointments).Ignore(x => x.Members)
       .Ignore(x => x.Contracts).Ignore(x => x.DomainEvents).Ignore(x => x.Owner)
       .Ignore(x => x.UserRooms));
    }

    private static void CreateIndex<TEntity>(this IElasticClient client, string indexName) where TEntity : class, IEntity
    {
        var pingResponse = client.Ping();
        if(!pingResponse.IsValid)
        {

        }
        if (!client.Indices.Exists(indexName).Exists)
        {
           var response = client.Indices.Create(indexName, i => i.Map<TEntity>(r => r.AutoMap()));
        }
    }
}

