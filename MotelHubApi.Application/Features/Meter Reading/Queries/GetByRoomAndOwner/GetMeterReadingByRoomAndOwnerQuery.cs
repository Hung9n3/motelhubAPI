using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;
public class GetMeterReadingByRoomAndOwnerQuery : BaseMeterReadingModel, IRequest<GetMeterReadingByRoomAndOwnerDto>
{
    public GetMeterReadingByRoomAndOwnerQuery(int id)
    {
        base.Id = id;
    }
}

internal class GetMeterReadingByRoomAndOwnerHandler : BaseHandler<MeterReading, GetMeterReadingByRoomAndOwnerQuery, IMeterReadingRepository, GetMeterReadingByRoomAndOwnerDto>
{
    public GetMeterReadingByRoomAndOwnerHandler(IUnitOfWork unitOfWork, IMeterReadingRepository repository, IMapper mapper) 
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetMeterReadingByRoomAndOwnerDto> Handle(GetMeterReadingByRoomAndOwnerQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByRoomAndOwner(request.Id, request.OwnerId.GetValueOrDefault());
        var result = base._mapper.Map<GetMeterReadingByRoomAndOwnerDto>(dbResult);
        return result;
    }
}
