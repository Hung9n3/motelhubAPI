using System;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;

public class CreateMeterReadingCommand : BaseMeterReadingModel, IRequest<MeterReading>
{
}

internal class CreateMeterReadingCommandHandler : BaseHandler<MeterReading, CreateMeterReadingCommand, IMeterReadingRepository, MeterReading>
{
    private readonly IValidator<CreateMeterReadingCommand> _validator;

    public CreateMeterReadingCommandHandler(IUnitOfWork unitOfWork, IMeterReadingRepository repository, IMapper mapper, IValidator<CreateMeterReadingCommand> validator)
        : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task<MeterReading> Handle(CreateMeterReadingCommand command, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(command);
        if(!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }

        var meterReading = base._mapper.Map<MeterReading>(command);
        var result = await _repository.AddAsync(meterReading);
        meterReading.AddDomainEvent(new MeterReadingCreatedEvent(meterReading));
        await _unitOfWork.Save(cancellationToken);
        return result;
    }
}

