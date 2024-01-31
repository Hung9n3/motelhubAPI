using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class UpdateAreaCommand : BaseAreaModel, IRequest
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
    public List<BaseRoomModel> Rooms { get; set; } = new List<BaseRoomModel>();
}

public class UpdateAreaCommandHandler : BaseHandler<Area, UpdateAreaCommand, IAreaRepository>
{
    IValidator<UpdateAreaCommand> _validator;
    public UpdateAreaCommandHandler(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper, IValidator<UpdateAreaCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            string message = string.Join(", ", validationResult.Errors.Select(a => a.ErrorMessage));
            throw new Exception($"{message}");
        }
        var dtoPhotoIds = request.Photos.Select(x => x.Id).ToList();
        var area = await base._repository.GetByIdAsync(
            request.Id, 
            new List<Expression<Func<Area, object>>> { x => x.Photos, x => x.Rooms});
        if(area is null)
        {
            throw new Exception("Not Found");
        }
        base._mapper.Map(request, area);
        area.Photos.UpdateRelated(request.Photos, base._mapper);
        area.Rooms.UpdateRelated(request.Rooms, base._mapper);
        area.AddDomainEvent(new AreaUpdatedEvent(area));
        await this._unitOfWork.Save(cancellationToken);
    }
}
