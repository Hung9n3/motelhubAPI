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
        var room = await base._repository.GetByIdAsync(
            request.Id,
            new List<Expression<Func<Room, object>>> { x => x.Photos, x => x.MeterReadings, x => x.Members});
        base._mapper.Map(request, room);

        room.Photos.UpdateRelated(request.Photos, base._mapper);
        room.MeterReadings.UpdateRelated(request.MeterReadings, base._mapper);
        room.AddDomainEvent(new RoomUpdatedEvent(room));
        await this._unitOfWork.Save(cancellationToken);
    }
}
