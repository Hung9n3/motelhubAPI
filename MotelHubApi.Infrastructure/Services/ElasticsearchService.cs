using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Nest;

namespace MotelHubApi.Infrastructure;
public class ElasticsearchService : IElasticsearchService
{
    private readonly IElasticClient _elasticClient;

    public ElasticsearchService(IElasticClient elasticClient)
    {
        this._elasticClient = elasticClient;
    }
    public async Task IndexDocument<TEntity>(TEntity document) where TEntity : class, IEntity
    {
        var indexResponse = await _elasticClient.IndexDocumentAsync(document);
        if (!indexResponse.IsValid)
        {
            // Handle indexing error
        }
    }

    public async Task<List<TEntity>> Search<TEntity>(SearchOptions searchOptions) where TEntity : class, IEntity
    {
        var searchContainer = new List<QueryContainer>();

        foreach (var query in searchOptions.SearchQueries)
        {
            searchContainer.Add(new()
            {
                
            });
        }

        var filterContainer = new List<QueryContainer>();

        var request = new SearchRequest<TEntity>()
        {
            Query = new BoolQuery
            {
                Must = searchContainer,
                Filter = filterContainer
            },
        };
        var searchResponse = await _elasticClient.SearchAsync<TEntity>(request);

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
