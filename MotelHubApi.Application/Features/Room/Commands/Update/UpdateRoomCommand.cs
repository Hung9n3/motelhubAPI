using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class UpdateRoomCommand : BaseRoomModel, IRequest
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
    public List<UserRoom> UserRooms { get; set; } = new List<UserRoom>();
    public List<BaseMeterReadingModel> MeterReadings { get; set; } = new List<BaseMeterReadingModel>();
}

public class UpdateRoomCommandHandler : BaseHandler<Room, UpdateRoomCommand, IRoomRepository>
{
    IValidator<UpdateRoomCommand> _validator;
    public UpdateRoomCommandHandler(IUnitOfWork unitOfWork, IRoomRepository repository, IMapper mapper, IValidator<UpdateRoomCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var dbResult = await base._repository.GetByIdAsync(
            request.Id,
            x => x.Photos, x => x.UserRooms);
        if (dbResult is null)
        {
            throw new KeyNotFoundException();
        }
        base._mapper.Map(request, dbResult);
        dbResult.Photos.UpdateRelated(request.Photos, base._mapper);
        dbResult.AddDomainEvent(new RoomUpdatedEvent(dbResult));
        await this._unitOfWork.Save(cancellationToken);
    }
}
