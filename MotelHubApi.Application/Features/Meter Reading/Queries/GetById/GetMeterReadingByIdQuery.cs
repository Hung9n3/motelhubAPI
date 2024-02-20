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

public class GetMeterReadingByIdQuery : IRequest<GetMeterReadingByIdDto>
{
    public int Id { get; set; }
    public GetMeterReadingByIdQuery(int id)
    {
        this.Id = id;
    }
}

internal class GetMeterReadingByIdQueryHandler : BaseHandler<MeterReading, GetMeterReadingByIdQuery, IMeterReadingRepository, GetMeterReadingByIdDto>
{
    public GetMeterReadingByIdQueryHandler(IUnitOfWork unitOfWork, IMeterReadingRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetMeterReadingByIdDto> Handle(GetMeterReadingByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(
            request.Id,
            x => x.Photos);
        var result = _mapper.Map<GetMeterReadingByIdDto>(dbResult);
        return result;
    }
}
