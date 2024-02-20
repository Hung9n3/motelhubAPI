using FluentValidation;

namespace MotelHubApi;

public class BaseContractValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseContractModel
{
    public BaseContractValidator()
    {
        RuleFor(cmd => cmd)
            .Must(x => !string.IsNullOrWhiteSpace(x.HostPhone) && !string.IsNullOrWhiteSpace(x.HostName) && x.EndDate is not null && x.StartDate is not null && !string.IsNullOrWhiteSpace(x.CustomerName) && !string.IsNullOrWhiteSpace(x.CustomerPhone) && !string.IsNullOrWhiteSpace(x.RoomName) && !string.IsNullOrWhiteSpace(x.RoomAddress))
            .WithMessage(x => $"{nameof(x.HostPhone)}, {nameof(x.StartDate)}, {nameof(x.EndDate)}, {nameof(x.CustomerName)}, {nameof(x.CustomerPhone)}, {nameof(x.HostName)}, {nameof(x.RoomName)}, {nameof(x.RoomAddress)} can not empty");
    }
}