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
    private readonly IElasticsearchService _searchService;
    public SearchRoomHandler(IUnitOfWork unitOfWork, IRoomRepository repository, IMapper mapper, IElasticsearchService searchServicee) : base(unitOfWork, repository, mapper)
    {
        _searchService = searchServicee;
    }

    public override async Task<List<SearchRoomResult>> Handle(SearchRoomQuery request, CancellationToken cancellationToken)
    {
        var queries = new List<SearchOptions>();

        var stringQueries = new List<string>();
        
        var result = base._mapper.Map<List<SearchRoomResult>>(null);
        return result;
    }
}
