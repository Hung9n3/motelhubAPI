using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class GetAreaByOwnerQuery : BaseAreaModel, IRequest<List<GetAreaByOwnerDto>> 
{
}

internal class GetAreaByOwnerQueryHandler : BaseHandler<Area, GetAreaByOwnerQuery, IAreaRepository, List<GetAreaByOwnerDto>>
{
    public GetAreaByOwnerQueryHandler(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<List<GetAreaByOwnerDto>> Handle(GetAreaByOwnerQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByUser(request.HostId);
        var result = _mapper.Map<List<GetAreaByOwnerDto>>(dbResult);
        return result;
    }
}
