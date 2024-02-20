using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class UpdateContractCommand : BaseContractModel, IRequest
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
}

public class UpdateContractCommandHandler : BaseHandler<Contract, UpdateContractCommand, IContractRepository>
{
    IValidator<UpdateContractCommand> _validator;
    public UpdateContractCommandHandler(IUnitOfWork unitOfWork, IContractRepository repository, IMapper mapper, IValidator<UpdateContractCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var dbResult = await base._repository.GetByIdAsync(
            request.Id,
            x => x.Photos);
        if(dbResult is null)
        {
            throw new KeyNotFoundException();
        }
        base._mapper.Map(request, dbResult);
        dbResult.Photos.UpdateRelated(request.Photos, base._mapper);
        dbResult.AddDomainEvent(new ContractUpdatedEvent(dbResult));
        await this._unitOfWork.Save(cancellationToken);
    }
}
