using System;
using FluentValidation;
namespace MotelHubApi;

public class CreateContractValidator : BaseContractValidator<CreateContractCommand>
{
    public CreateContractValidator() : base()
    {
        RuleFor(cmd => cmd)
            .Must(x => x.RoomId.IsPositive() && x.HostId.IsPositive() && x.CustomerId.IsPositive())
            .WithMessage(x => $"{nameof(x.RoomId)}, {nameof(x.HostId)}, {nameof(x.CustomerId)} can not empty");
    }
}

