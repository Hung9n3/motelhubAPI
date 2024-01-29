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

public class UpdateMeterReadingCommand : BaseMeterReadingModel, IRequest
{
}

public class UpdateMeterReadingCommandHandler : BaseHandler<MeterReading, UpdateMeterReadingCommand, IMeterReadingRepository>
{
    IValidator<UpdateMeterReadingCommand> _validator;
    public UpdateMeterReadingCommandHandler(IUnitOfWork unitOfWork, IMeterReadingRepository repository, IMapper mapper, IValidator<UpdateMeterReadingCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateMeterReadingCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var meterReading = this._mapper.Map<MeterReading>(request);
        await this._repository.UpdateAsync(meterReading);
        meterReading.AddDomainEvent(new MeterReadingUpdatedEvent(meterReading));
        await this._unitOfWork.Save(cancellationToken);
    }
}
