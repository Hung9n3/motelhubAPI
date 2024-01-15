using System;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public record CreateRoomCommand(string? Name, int AreaId, int OwnerId, List<Photo> Photos) : IRequest<int>,IMapFrom<Room>;

internal class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand,int>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		this._unitOfWork = unitOfWork;
		this._mapper = mapper;
	}

	public async Task<int> Handle(CreateRoomCommand command, CancellationToken cancellationToken = default)
	{
		var room = new Room
		{
			Name = command.Name,
			AreaId = command.AreaId,
			OwnerId = command.OwnerId,
			Photos = command.Photos,
		};

		await _unitOfWork.Repository<Room>().AddAsync(room);
		room.AddDomainEvent(new RoomCreatedEvent(room));
		await _unitOfWork.Save(cancellationToken);
		return room.Id;
	}
}
