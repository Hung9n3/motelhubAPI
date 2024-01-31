using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class CreatePhotoCommand : BasePhotoModel, IRequest<Photo>
{
}

internal class CreatePhotoCommandHandler : BaseHandler<Photo, CreatePhotoCommand, IPhotoRepository, Photo>
{
    private readonly IValidator<CreatePhotoCommand> _validator;

    public CreatePhotoCommandHandler(IUnitOfWork unitOfWork, IPhotoRepository repository, IMapper mapper, IValidator<CreatePhotoCommand> validator)
        : base(unitOfWork, repository, mapper)
    {
        _validator = validator;
    }

    public override async Task<Photo> Handle(CreatePhotoCommand command, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(command);
        if (!validationResult.IsValid)
        {
            string message = string.Join(", ", validationResult.Errors.Select(a => a.ErrorMessage));
            throw new Exception($"{message}");
        }

        var photo = _mapper.Map<Photo>(command);
        var result = await _repository.AddAsync(photo);
        photo.AddDomainEvent(new PhotoCreatedEvent(photo));
        await _unitOfWork.Save(cancellationToken);
        return result;
    }
}

