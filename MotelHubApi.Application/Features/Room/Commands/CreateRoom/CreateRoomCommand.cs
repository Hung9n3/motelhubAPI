using System;
using AutoMapper;
using MediatR;
using MotelHubApi.Shared;

namespace MotelHubApi;

public class CreateRoomCommand : BaseRoomCommand, IRequest<int>
{
	public string Name { get; set; } = string.Empty;
	public double Acreage { get; set; }
    public int OwnerId { get; set; }
    public List<Photo> Photos { get; set; } = new List<Photo>();
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
