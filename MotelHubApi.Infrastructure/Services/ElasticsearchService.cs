using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MotelHubApi.Infrastructure;
public class ElasticsearchService: IElasticsearchService
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

    public async Task<List<TEntity>> SearchByName<TEntity>(string keyWord, PagingOptions pagingOptions) where TEntity : class, IEntity
    {
        var searchDescriptor = new SearchDescriptor<TEntity>()
        .Query(q => q
            .QueryString(qs => qs.Query($"*{keyWord}*"))
        )
        .Skip(pagingOptions.PageCount*pagingOptions.PageSize)
        .Size(pagingOptions.PageSize);

        var searchResponse = await _elasticClient.SearchAsync<TEntity>(searchDescriptor);

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
