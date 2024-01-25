using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class DeleteRoomCommand : BaseRoomModel, IRequest
{
}

public class DeleteRoomCommandHandler : BaseHandler<Room, DeleteRoomCommand, IRoomRepository>
{
    public DeleteRoomCommandHandler(IUnitOfWork unitOfWork, IRoomRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = base._mapper.Map<Room>(request);
        await base._repository.DeleteAsync(room);
        room.AddDomainEvent(new RoomDeletedEvent(room));
        await base._unitOfWork.Save(cancellationToken);
    }
}
