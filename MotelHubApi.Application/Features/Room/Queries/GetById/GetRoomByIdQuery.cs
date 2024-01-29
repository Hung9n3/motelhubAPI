using AutoMapper;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetRoomByIdQuery : IRequest<GetRoomByIdDto>
{
    public int Id { get; set; }
}

internal class GetRoomByIdQueryHandler : BaseHandler<Room, GetRoomByIdQuery, IRoomRepository, GetRoomByIdDto>
{
    public GetRoomByIdQueryHandler(IUnitOfWork unitOfWork, IRoomRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetRoomByIdDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = base._repository.GetByIdAsync(
            request.Id, 
            new List<Expression<Func<Room, object>>> { x => x.Area, x => x.Members, x => x.MeterReadings, x => x.Photos, x => x.Contracts });
        return new GetRoomByIdDto();
    }
}
