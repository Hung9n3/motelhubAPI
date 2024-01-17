using System;
using FluentValidation;
namespace MotelHubApi;

public class CreateAreaValidator : BaseAreaValidator<CreateAreaCommand>
{
    public CreateAreaValidator() : base()
    {
        RuleFor(command => command.Address).NotNull().NotEmpty().WithMessage($"{nameof(CreateAreaCommand.Address)} can not be empty");
    }
}

