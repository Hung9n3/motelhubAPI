using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nest;

namespace MotelHubApi.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        services.AddElasticsearch(configuration);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IAuthenticationService, AuthenticationService>()
                .AddTransient<ITokenService, TokenService>()
                .AddTransient<IElasticsearchService, ElasticsearchService>()
                ;
    }

    private static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ElasticsearchConfig>(configuration.GetSection("ElasticsearchSettings"));
        var elasticsearchConfig = configuration.GetSection(nameof(ElasticsearchConfig)).Get<ElasticsearchConfig>();
        var connectionSettings = new ConnectionSettings(new Uri(elasticsearchConfig!.Url))
                        .PrettyJson()
                        .DefaultIndex(elasticsearchConfig?.DefaultIndex);
        connectionSettings.AddDefaultMappings();
        var client = new ElasticClient(connectionSettings);

        services.AddSingleton<IElasticClient>(client);

        client.CreateIndex(elasticsearchConfig!.DefaultIndex);
    }

    private static void AddDefaultMappings(this ConnectionSettings settings)
    {
        settings.DefaultMappingFor<Room>(r => r);
    }

    private static void CreateIndex(this IElasticClient client, string indexName)
    {
        if (!client.Indices.Exists(indexName).Exists)
        {
            client.Indices.Create(indexName, i => i.Map<Room>(r => r.AutoMap()));
        }
    }
}

