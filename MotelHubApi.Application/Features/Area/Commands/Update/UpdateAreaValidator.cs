using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateAreaValidator : BaseAreaValidator<UpdateAreaCommand>
{
    public UpdateAreaValidator() : base()
    {
    }
}

