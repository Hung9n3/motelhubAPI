using FluentValidation;

namespace MotelHubApi;

public class BaseContractValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseContractModel
{
    public BaseContractValidator()
    {
    }
}