using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class CreateAreaCommand : BaseAreaModel, IRequest<Area>
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
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
            string message = string.Join(", ", validationResult.Errors.Select(a => a.ErrorMessage));
            throw new Exception($"{message}");
        }

        var area = base._mapper.Map<Area>(command);
        var result = await _repository.AddAsync(area);
        area.AddDomainEvent(new AreaCreatedEvent(area));
        await _unitOfWork.Save(cancellationToken);
        return result;
    }
}

