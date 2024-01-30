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

public class UpdateRoomCommand : BaseRoomModel, IRequest
{
    public ICollection<UserRoom> UserRooms { get; set; } = new HashSet<UserRoom>();
    public ICollection<BaseUserModel> Members { get; set; } = new HashSet<BaseUserModel>();
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseMeterReadingModel> MeterReadings { get; set; } = new HashSet<BaseMeterReadingModel>();
    public ICollection<BaseContractModel> Contracts { get; set; } = new HashSet<BaseContractModel>();
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
        var room = this._mapper.Map<Room>(request);
        await this._repository.UpdateAsync(room);
        room.AddDomainEvent(new RoomUpdatedEvent(room));
        await this._unitOfWork.Save(cancellationToken);
    }
}
