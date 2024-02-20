using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetContractByIdQuery : BaseContractModel, IRequest<GetContractByIdDto>
{
}

internal class GetContractByIdHandler : BaseHandler<Contract, GetContractByIdQuery, IContractRepository, GetContractByIdDto>
{
    public GetContractByIdHandler(IUnitOfWork unitOfWork, IContractRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetContractByIdDto> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(
            request.Id, 
            x => x.Bills, x => x.Photos, x => x.Host, x => x.Customer, x => x.Room);
        var result = base._mapper.Map<GetContractByIdDto>(dbResult);
        return result;
    }
}
