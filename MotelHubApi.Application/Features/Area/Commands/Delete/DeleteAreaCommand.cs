using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class DeleteAreaCommand : BaseAreaModel, IRequest
{
}

public class DeleteAreaCommandHandler : BaseHandler<Area, DeleteAreaCommand, IAreaRepository>
{
    public DeleteAreaCommandHandler(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
    {
        var area = base._mapper.Map<Area>(request);
        await base._repository.DeleteAsync(area);
        area.AddDomainEvent(new AreaDeletedEvent(area));
        await base._unitOfWork.Save(cancellationToken);
    }
}
