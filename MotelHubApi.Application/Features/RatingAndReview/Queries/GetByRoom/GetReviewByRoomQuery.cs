using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;
public class GetReviewByRoomQuery : BaseRatingAndReviewModel, IRequest<List<GetReviewByRoomDto>> 
{
    public PagingOptions PagingOptions { get; set; } = new PagingOptions();
    public GetReviewByRoomQuery(int roomId, PagingOptions pagingOptions)
    {
        this.PagingOptions = pagingOptions;
    }
}

internal class GetReviewByRoomHandler : BaseHandler<RatingAndReview, GetReviewByRoomQuery, IRatingAndReviewRepository, List<GetReviewByRoomDto>>
{
    public GetReviewByRoomHandler(IUnitOfWork unitOfWork, IRatingAndReviewRepository repository, IMapper mapper) 
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<List<GetReviewByRoomDto>> Handle(GetReviewByRoomQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByRoom(request.PagingOptions, request.RoomId);
        var result = base._mapper.Map<List<GetReviewByRoomDto>>(dbResult);
        return result;
    }
}
