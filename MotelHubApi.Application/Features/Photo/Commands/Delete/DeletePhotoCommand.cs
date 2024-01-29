using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class DeletePhotoCommand : BasePhotoModel, IRequest
{
}

public class DeletePhotoCommandHandler : BaseHandler<Photo, DeletePhotoCommand, IPhotoRepository>
{
    public DeletePhotoCommandHandler(IUnitOfWork unitOfWork, IPhotoRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        var Photo = _mapper.Map<Photo>(request);
        await _repository.DeleteAsync(Photo);
        Photo.AddDomainEvent(new PhotoDeletedEvent(Photo));
        await _unitOfWork.Save(cancellationToken);
    }
}
