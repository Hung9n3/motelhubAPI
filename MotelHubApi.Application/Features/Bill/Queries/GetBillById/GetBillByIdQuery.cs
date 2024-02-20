using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetBillByIdQuery : BaseBillModel, IRequest<GetBillByIdDto>
{
}

internal class GetBillByIdHandler : BaseHandler<Bill, GetBillByIdQuery, IBillRepository, GetBillByIdDto>
{
    public GetBillByIdHandler(IUnitOfWork unitOfWork, IBillRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetBillByIdDto> Handle(GetBillByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(
            request.Id, 
            x => x.Contract);
        var result = base._mapper.Map<GetBillByIdDto>(dbResult);
        return result;
    }
}
