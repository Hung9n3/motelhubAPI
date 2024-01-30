using FluentValidation;

namespace MotelHubApi;

public class BaseAreaValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseAreaModel
{
    public BaseAreaValidator()
    {
        RuleFor(command => command.HostId).NotEqual(0).WithMessage("HostId is required for Area")
                                          .NotNull().WithMessage("HostId is required for Area");
        RuleFor(command => command.Address).NotNull().NotEmpty().WithMessage($"{nameof(CreateAreaCommand.Address)} can not be empty");
    }
}