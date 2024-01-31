using FluentValidation;

namespace MotelHubApi;

public class BaseMeterReadingValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseMeterReadingModel
{
    public BaseMeterReadingValidator()
    {
        RuleFor(command => command)
            .Must(command => command.LastMonth.IsPositive() && command.ThisMonth.IsPositive()).WithMessage("Last month and This month can not empty")
            .Must(command => command.LastMonth <= command.ThisMonth).WithMessage("Last month can not greater than this month");
        RuleFor(command => command.Price).NotNull().NotEmpty().WithMessage("Price is required");
    }
}