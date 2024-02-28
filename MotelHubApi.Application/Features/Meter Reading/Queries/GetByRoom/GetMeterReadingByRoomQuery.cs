using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;
public class GetMeterReadingByRoomQuery : BaseMeterReadingModel, IRequest<GetMeterReadingByRoomDto>
{
    public GetMeterReadingByRoomQuery(int id)
    {
        base.Id = id;
    }
}

internal class GetMeterReadingByRoomHandler : BaseHandler<MeterReading, GetMeterReadingByRoomQuery, IMeterReadingRepository, GetMeterReadingByRoomDto>
{
    public GetMeterReadingByRoomHandler(IUnitOfWork unitOfWork, IMeterReadingRepository repository, IMapper mapper) 
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetMeterReadingByRoomDto> Handle(GetMeterReadingByRoomQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByRoom(request.Id);
        var result = base._mapper.Map<GetMeterReadingByRoomDto>(dbResult);
        return result;
    }
}
