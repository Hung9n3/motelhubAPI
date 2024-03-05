using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MotelHubApi.Infrastructure;
public class ElasticsearchService<TEntity> : IElasticsearchService<TEntity> where TEntity : class, IEntity
{
    private readonly IElasticClient _elasticClient;
    private readonly string _indexName;

    public ElasticsearchService(string connectionString, string indexName)
    {
        var connectionPool = new SingleNodeConnectionPool(new Uri(connectionString));
        var connectionSettings = new ConnectionSettings(connectionPool)
            .DefaultIndex(indexName);

        _elasticClient = new ElasticClient(connectionSettings);
        _indexName = indexName;
    }
    public async Task IndexDocument(TEntity document)
    {
        var indexResponse = _elasticClient.IndexDocument(document);
        if (!indexResponse.IsValid)
        {
            // Handle indexing error
        }
    }

    public async Task<List<TEntity>> SearchList(QueryContainer[] queries)
    {
        var searchDescriptor = new SearchDescriptor<TEntity>()
        .Index(_indexName)
        .Query(q => q
            .Bool(b => b
                .Must(queries)
                )
        );

        var searchResponse = _elasticClient.Search<TEntity>(searchDescriptor);

        if (searchResponse.IsValid)
        {
            return searchResponse.Documents.ToList();
        }
        else
        {
            // Handle search error
            return new List<TEntity>();
        }
    }
}
