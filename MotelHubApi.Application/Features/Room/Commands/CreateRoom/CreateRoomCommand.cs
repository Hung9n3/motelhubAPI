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
		var room = _mapper.Map<Room>(command);
		await _unitOfWork.Repository<Room>().AddAsync(room);
		room.AddDomainEvent(new RoomCreatedEvent(room));
		await _unitOfWork.Save(cancellationToken);
		return room.Id;
	}
}
