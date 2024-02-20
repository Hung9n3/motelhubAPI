using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class GetAreaByIdQuery : IRequest<GetAreaByIdDto>
{
    public int AreaId { get; set; }
    public GetAreaByIdQuery(int areaId)
    {
        this.AreaId = areaId;
    }
}

internal class GetAreaByIdQueryHandler : BaseHandler<Area, GetAreaByIdQuery, IAreaRepository, GetAreaByIdDto>
{
    public GetAreaByIdQueryHandler(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetAreaByIdDto> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(
            request.AreaId,
            x => x.Rooms, x => x.Host, x => x.Photos);
        var result = base._mapper.Map<GetAreaByIdDto>(dbResult);
        return result;
    }
}
