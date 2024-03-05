using AutoMapper;
using MediatR;

namespace MotelHubApi;
public class SearchRoomQuery : BaseRoomModel, IRequest<List<SearchRoomResult>>
{
    public double? FromAcreage { get; set; }
    public double? ToAcreage { get; set; }
    public double? AboveRating { get; set; }
    public string SearchAddress { get; set; } = string.Empty;
    public string SearchName { get; set; } = string.Empty;
    public int? FromPrice { get; set; }
    public int? ToPrice { get; set; }
}

internal class SearchRoomHandler : BaseHandler<Room, SearchRoomQuery, IRoomRepository, List<SearchRoomResult>>
{
    private readonly IElasticsearchService<Room> _searchService;
    public SearchRoomHandler(IUnitOfWork unitOfWork, IRoomRepository repository, IMapper mapper, IElasticsearchService<Room> searchServicee) : base(unitOfWork, repository, mapper)
    {
        _searchService = searchServicee;
    }

    public override async Task<List<SearchRoomResult>> Handle(SearchRoomQuery request, CancellationToken cancellationToken)
    {
        var queries = new List<SearchingQuery>();

        var stringQueries = new List<string>();
        if(request.SearchName != null)
        {
            stringQueries.Add(request.GetContainStringQuery(nameof(request.Name), request.SearchName));
        }
        if(request.FromAcreage != null && request.ToAcreage != null)
        {
            stringQueries.Add(request.GetRangeQuery(nameof(request.Acreage), request.FromAcreage, request.ToAcreage));
        }
        if(request.AboveRating != null)
        {
            stringQueries.Add(request.GetGreaterThanOrEqualQuery(nameof(request.Rating), request.AboveRating));
        }
        if(request.FromPrice != null && request.ToPrice != null)
        {
            stringQueries.Add(request.GetRangeQuery(nameof(request.Price), request.FromPrice, request.ToPrice));
        }
        var searchResult = await this._searchService.SearchList(queries.ToArray()); 
        var result = base._mapper.Map<List<SearchRoomResult>>(searchResult);
        return result;
    }
}
