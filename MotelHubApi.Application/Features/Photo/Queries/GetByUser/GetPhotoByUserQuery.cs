using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class GetPhotoByUserQuery : BasePhotoModel, IRequest<List<GetPhotoByUserDto>>
{
    public GetPhotoByUserQuery(int userId)
    {
        this.Id = userId;
    }
}

internal class GetPhotoByUserHandler : BaseHandler<Photo, GetPhotoByUserQuery, IPhotoRepository, List<GetPhotoByUserDto>>
{
    public GetPhotoByUserHandler(IUnitOfWork unitOfWork, IPhotoRepository repository, IMapper mapper)
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<List<GetPhotoByUserDto>> Handle(GetPhotoByUserQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByUser(request.UserId);
        var result = base._mapper.Map<List<GetPhotoByUserDto>>(dbResult);
        return result;
    }
}
