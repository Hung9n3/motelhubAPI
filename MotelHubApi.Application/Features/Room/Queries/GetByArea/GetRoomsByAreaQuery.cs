using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MotelHubApi;

public class GetRoomsByAreaQuery : BaseRoomModel, IRequest<IEnumerable<GetRoomsByAreaDto>>
{
	public GetRoomsByAreaQuery(int? areaId)
	{
		this.AreaId = areaId;
	}
}

internal class GetRoomsByAreaQueryHandler : IRequestHandler<GetRoomsByAreaQuery, IEnumerable<GetRoomsByAreaDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<GetRoomsByAreaQuery> _validator;

    public GetRoomsByAreaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRoomRepository roomRepository, IValidator<GetRoomsByAreaQuery> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
        _roomRepository = roomRepository;
    }
    public async Task<IEnumerable<GetRoomsByAreaDto>> Handle(GetRoomsByAreaQuery query, CancellationToken ct = default)
    {
        var validationResults = _validator.Validate(query);
        if(!validationResults.IsValid)
        {
            throw new Exception($"{validationResults.Errors}");
        }
        var dbResult = await _roomRepository.GetByArea(query.AreaId);       
        return _mapper.Map<List<GetRoomsByAreaDto>>(dbResult);
    }
}
