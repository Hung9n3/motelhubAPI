using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;
public class CreateRatingAndReviewCommand : BaseRatingAndReviewModel, IRequest
{
}

internal class RatingAndReviewCreateCommandHandler : BaseHandler<RatingAndReview, CreateRatingAndReviewCommand, IRatingAndReviewRepository>
{
    private readonly IValidator<CreateRatingAndReviewCommand> _validator;
    public RatingAndReviewCreateCommandHandler(IUnitOfWork unitOfWork, IRatingAndReviewRepository repository, IMapper mapper, IValidator<CreateRatingAndReviewCommand> validator) 
        : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(CreateRatingAndReviewCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            string message = string.Join(", ", validationResult.Errors.Select(a => a.ErrorMessage));
            throw new Exception($"{message}");
        }

        var ratingAndReview = _mapper.Map<RatingAndReview>(request);
        var result = await _repository.AddAsync(ratingAndReview);
        ratingAndReview.AddDomainEvent(new RatingAndReviewCreatedEvent(ratingAndReview));
        await _unitOfWork.Save(cancellationToken);
    }
}
