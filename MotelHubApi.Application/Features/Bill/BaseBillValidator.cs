using FluentValidation;

namespace MotelHubApi;

public class BaseBillValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseBillModel
{
    public BaseBillValidator()
    {
        RuleFor(command => command.ContractId).NotEqual(0).NotNull().WithMessage("Contract is required when creating Bill");
    }
}