using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi;

public record GetRoomsByAreaQuery : IRequest<IEnumerable<GetRoomsByAreaDto>>
{
	public int AreaId { get; set; }

	public GetRoomsByAreaQuery(int areaId)
	{
		this.AreaId = areaId;
	}
}

internal class GetRoomsByAreaQueryHandler : IRequestHandler<GetRoomsByAreaQuery, IEnumerable<GetRoomsByAreaDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRoomsByAreaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetRoomsByAreaDto>> Handle(GetRoomsByAreaQuery query, CancellationToken ct = default)
    {
        return await _unitOfWork.Repository<Room>().Entities
            .Where(x => x.AreaId == query.AreaId)
            .ProjectTo<GetRoomsByAreaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: ct);
    }
}
