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

public class GetUserByIdQuery : IRequest<GetUserByIdDto>
{
    public int Id { get; set; }
    public GetUserByIdQuery(int id)
    {
        this.Id = id;
    }
}

internal class GetUserByIdQueryHandler : BaseHandler<User, GetUserByIdQuery, IUserRepository, GetUserByIdDto>
{
    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IUserRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(
            request.Id);
        var result = _mapper.Map<GetUserByIdDto>(dbResult);
        return result;
    }
}
