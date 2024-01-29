using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class CreateContractCommand : BaseContractModel, IRequest<Contract>
{
}

internal class CreateContractCommandHandler : BaseHandler<Contract, CreateContractCommand, IContractRepository, Contract>
{
    private readonly IValidator<CreateContractCommand> _validator;

    public CreateContractCommandHandler(IUnitOfWork unitOfWork, IContractRepository repository, IMapper mapper, IValidator<CreateContractCommand> validator)
        : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task<Contract> Handle(CreateContractCommand command, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(command);
        if(!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }

        var cContract = base._mapper.Map<Contract>(command);
        var result = await _repository.AddAsync(cContract);
        cContract.AddDomainEvent(new ContractCreatedEvent(cContract));
        await _unitOfWork.Save(cancellationToken);
        return result;
    }
}

