using AutoMapper;
using MediatR;

namespace MotelHubApi;
public class GetRatingAndReviewByIdQuery : BaseRatingAndReviewModel, IRequest<GetRatingAndReviewByIdDto>
{
    public GetRatingAndReviewByIdQuery(int id)
    {
        base.Id = id;
    }
}

internal class GetRatingAndReviewByIdHandler : BaseHandler<RatingAndReview, GetRatingAndReviewByIdQuery, IRatingAndReviewRepository, GetRatingAndReviewByIdDto>
{
    public GetRatingAndReviewByIdHandler(IUnitOfWork unitOfWork, IRatingAndReviewRepository repository, IMapper mapper) 
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetRatingAndReviewByIdDto> Handle(GetRatingAndReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(request.Id);
        var result = base._mapper.Map<GetRatingAndReviewByIdDto>(dbResult);
        return result;
    }
}
