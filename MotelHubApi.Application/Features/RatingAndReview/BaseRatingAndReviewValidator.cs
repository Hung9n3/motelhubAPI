using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MotelHubApi;

public class BaseRatingAndReviewValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseRatingAndReviewModel
{
    public BaseRatingAndReviewValidator()
    {
        RuleFor(cmd => cmd).Must(cmd => cmd.UserId * cmd.RoomId > 0).WithMessage(x => $"User or Room are lacked");
    }
}
