using FluentValidation;

namespace MotelHubApi;

public class BaseMeterReadingValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseMeterReadingModel
{
    public BaseMeterReadingValidator()
    {
        RuleFor(command => command.Value).NotEqual(0).NotNull().WithMessage("Value is required");
        RuleFor(command => command.Price).NotNull().NotEmpty().WithMessage("Price is required");
    }
}