using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class CreateBillCommand : BaseBillModel, IRequest<Bill>
{
}

internal class CreateBillCommandHandler : BaseHandler<Bill, CreateBillCommand, IBillRepository, Bill>
{
    private readonly IValidator<CreateBillCommand> _validator;

    public CreateBillCommandHandler(IUnitOfWork unitOfWork, IBillRepository repository, IMapper mapper, IValidator<CreateBillCommand> validator)
        : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task<Bill> Handle(CreateBillCommand command, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(command);
        if(!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }

        var Bill = base._mapper.Map<Bill>(command);
        var result = await _repository.AddAsync(Bill);
        Bill.AddDomainEvent(new BillCreatedEvent(Bill));
        await _unitOfWork.Save(cancellationToken);
        return result;
    }
}

