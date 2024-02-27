using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateRatingAndReviewValidator : BaseRatingAndReviewValidator<UpdateRatingAndReviewCommand>
{
    public UpdateRatingAndReviewValidator() : base()
    {
    }
}

