using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class UpdatePhotoCommand : BasePhotoModel, IRequest
{
}

public class UpdatePhotoCommandHandler : BaseHandler<Photo, UpdatePhotoCommand, IPhotoRepository>
{
    IValidator<UpdatePhotoCommand> _validator;
    public UpdatePhotoCommandHandler(IUnitOfWork unitOfWork, IPhotoRepository repository, IMapper mapper, IValidator<UpdatePhotoCommand> validator) : base(unitOfWork, repository, mapper)
    {
        _validator = validator;
    }

    public override async Task Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var Photo = _mapper.Map<Photo>(request);
        await _repository.UpdateAsync(Photo);
        Photo.AddDomainEvent(new PhotoUpdatedEvent(Photo));
        await _unitOfWork.Save(cancellationToken);
    }
}
