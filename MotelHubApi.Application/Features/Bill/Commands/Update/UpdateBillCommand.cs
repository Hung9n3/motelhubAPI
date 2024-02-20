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

public class UpdateBillCommand : BaseBillModel, IRequest
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
}

public class UpdateBillCommandHandler : BaseHandler<Bill, UpdateBillCommand, IBillRepository>
{
    IValidator<UpdateBillCommand> _validator;
    public UpdateBillCommandHandler(IUnitOfWork unitOfWork, IBillRepository repository, IMapper mapper, IValidator<UpdateBillCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateBillCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var dbResult = await base._repository.GetByIdAsync(
            request.Id);
        if (dbResult is null)
        {
            throw new KeyNotFoundException();
        }
        base._mapper.Map(request, dbResult);
        
        dbResult.AddDomainEvent(new BillUpdatedEvent(dbResult));
        await this._unitOfWork.Save(cancellationToken);
    }
}
