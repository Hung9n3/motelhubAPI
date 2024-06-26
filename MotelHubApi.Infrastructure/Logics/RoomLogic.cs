using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace MotelHubApi.Infrastructure;

public class RoomLogic : BaseLogic<Room, IRoomRepository>, IRoomLogic
{
    //private readonly IElasticClient _elasticClient;
    public RoomLogic(IRoomRepository repository, RepositoryContext repositoryContext/*, IElasticClient elasticClient*/) : base(repository, repositoryContext)
    {
        //this._elasticClient = elasticClient;
    }

    public override async Task SaveAsync(Room entity)
    {
        var includeExpressions = new List<Expression<Func<Room, object>>>()
        {
            x => x.Area!,
            x => x.Area!.Host!
        }.ToArray();
        var existed = await base._repository.GetByIdAsync(entity.Id, includeExpressions);
        await base.SaveAsync(entity);
        //if (existed != null)
        //{
        //    var document = new RoomIndex
        //    {
        //        Id = existed.Id,
        //        Acreage = existed.Acreage,
        //        Address = existed.Area!.Address,
        //        ContactPhone = existed.Area.Host.PhoneNumber,
        //        Price = existed.Price
        //    };
        //    var updateResponse = this._elasticClient.Update<RoomIndex>(entity.Id, r => r.Doc(document)
        //                                                                           .Index("room")
        //                                                                        );
        //}
        //else
        //{
        //    var room = await base._repository.GetByIdAsync(entity.Id, includeExpressions);
        //    var document = new RoomIndex
        //    {
        //        Id = room.Id,
        //        Acreage = room.Acreage,
        //        Address = room.Area!.Address,
        //        ContactPhone = room.Area.Host.PhoneNumber,
        //        Price = entity.Price
        //    };
        //    var response = await this._elasticClient.IndexDocumentAsync(entity);
        //}
    }

    public async Task<List<Room>> Search(SearchOptions options)
    {
        var result = new List<Room>();
        //var boolQuery = new BoolQuery();
        //var fullQuery = new List<QueryContainer>();
        //foreach(var searchQuery in options.SearchQueries)
        //{
        //    var containQuery = new QueryStringQuery
        //    {
        //        DefaultField = searchQuery.Field,
        //        Query = $"*{searchQuery.Value}*"
        //    };
        //    fullQuery.Add(containQuery);
        //}
        //foreach(var rangeFilter in options.RangeFilters)
        //{
        //    var rangeQuery = new NumericRangeQuery { 
        //        Field = rangeFilter.Field,
        //        GreaterThanOrEqualTo = double.TryParse(rangeFilter.From, out var from) ? from : 0,
        //        LessThanOrEqualTo = double.TryParse(rangeFilter.To, out var to) ? to : from,
        //    };
        //    fullQuery.Add(rangeQuery);
        //}
        //boolQuery.Must = fullQuery;
        //var searchRequest = new SearchRequest<RoomIndex>
        //{
        //    Query = boolQuery
        //};
        //var response = await this._elasticClient.SearchAsync<RoomIndex>(searchRequest);
        //result = await base._repository.Entities.Where(r => response.Documents.Select(x => x.Id).Contains(r.Id)).ToListAsync();
        return result;
    }
}
