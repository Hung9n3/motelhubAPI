using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class CreateAreaCommand : BaseAreaModel, IRequest<Area>
{
	public string Name { get; set; } = string.Empty;
}

internal class CreateAreaCommandHandler : BaseHandler<Area, CreateAreaCommand, IAreaRepository, Area>
{
    private readonly IValidator<CreateAreaCommand> _validator;

    public CreateAreaCommandHandler(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper, IValidator<CreateAreaCommand> validator)
        : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task<Area> Handle(CreateAreaCommand command, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(command);
        if(!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }

        var area = base._mapper.Map<Area>(command);

        var result = await _repository.AddAsync(area);
        await _unitOfWork.Save(cancellationToken);
        return result;
    }
}

