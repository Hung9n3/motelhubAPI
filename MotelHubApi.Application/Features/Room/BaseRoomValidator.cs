using FluentValidation;

namespace MotelHubApi;

public class BaseRoomValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseRoomModel
{
	public BaseRoomValidator()
	{
		RuleFor(command => command.AreaId).NotEqual(0).NotNull().WithMessage("Area is required");
	}
}

