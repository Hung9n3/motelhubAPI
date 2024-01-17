using FluentValidation;

namespace MotelHubApi;

public class BaseAreaValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseAreaModel
{
    public BaseAreaValidator()
    {
        RuleFor(command => command.HostId).NotEqual(0).NotNull().WithMessage("Area is required");
    }
}