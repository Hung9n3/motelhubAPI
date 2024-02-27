using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class DeleteRatingAndReviewCommand : BaseRatingAndReviewModel, IRequest
{
}

public class DeleteRatingAndReviewCommandHandler : BaseHandler<RatingAndReview, DeleteRatingAndReviewCommand, IRatingAndReviewRepository>
{
    public DeleteRatingAndReviewCommandHandler(IUnitOfWork unitOfWork, IRatingAndReviewRepository repository, IMapper mapper)
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task Handle(DeleteRatingAndReviewCommand request, CancellationToken cancellationToken)
    {
        var ratingAndReview = base._mapper.Map<RatingAndReview>(request);
        await base._repository.DeleteAsync(ratingAndReview);
        ratingAndReview.AddDomainEvent(new RatingAndReviewDeletedEvent(ratingAndReview));
        await base._unitOfWork.Save(cancellationToken);
    }
}
