using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class UpdateAreaCommand : BaseAreaModel, IRequest
{
}

public class UpdateAreaCommandHandler : BaseHandler<Area, UpdateAreaCommand, IAreaRepository>
{
    IValidator<UpdateAreaCommand> _validator;
    public UpdateAreaCommandHandler(IUnitOfWork unitOfWork, IAreaRepository repository, IMapper mapper, IValidator<UpdateAreaCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var area = this._mapper.Map<Area>(request);
        await this._repository.UpdateAsync(area);
        area.AddDomainEvent(new AreaUpdatedEvent(area));
        await this._unitOfWork.Save(cancellationToken);
    }
}
