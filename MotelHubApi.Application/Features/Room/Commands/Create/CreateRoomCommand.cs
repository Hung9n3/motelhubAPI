using System;
using AutoMapper;
using MediatR;
using MotelHubApi.Shared;

namespace MotelHubApi;

public class CreateRoomCommand : BaseRoomModel, IRequest<int>
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
}

internal class CreateRoomCommandHandler : BaseHandler<Room, CreateRoomCommand, IRoomRepository,int>
{
	public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IRoomRepository repository)
		: base (unitOfWork, repository, mapper)
	{
	}

	public override async Task<int> Handle(CreateRoomCommand command, CancellationToken cancellationToken = default)
	{
		var room = base._mapper.Map<Room>(command);
		await base._repository.AddAsync(room);
		room.AddDomainEvent(new RoomCreatedEvent(room));
		await _unitOfWork.Save(cancellationToken);
		return room.Id;
	}
}
