using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class UpdateRatingAndReviewCommand : BaseRatingAndReviewModel, IRequest
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
}

public class UpdateRatingAndReviewCommandHandler : BaseHandler<RatingAndReview, UpdateRatingAndReviewCommand, IRatingAndReviewRepository>
{
    IValidator<UpdateRatingAndReviewCommand> _validator;
    public UpdateRatingAndReviewCommandHandler(IUnitOfWork unitOfWork, IRatingAndReviewRepository repository, IMapper mapper, IValidator<UpdateRatingAndReviewCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateRatingAndReviewCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var dbResult = await base._repository.GetByIdAsync(
            request.Id);
        if(dbResult is null)
        {
            throw new KeyNotFoundException();
        }
        base._mapper.Map(request, dbResult);
        dbResult.AddDomainEvent(new RatingAndReviewUpdatedEvent(dbResult));
        await this._unitOfWork.Save(cancellationToken);
    }
}
