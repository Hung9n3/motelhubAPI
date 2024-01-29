using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class DeleteMeterReadingCommand : BaseMeterReadingModel, IRequest
{
}

public class DeleteMeterReadingCommandHandler : BaseHandler<MeterReading, DeleteMeterReadingCommand, IMeterReadingRepository>
{
    public DeleteMeterReadingCommandHandler(IUnitOfWork unitOfWork, IMeterReadingRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task Handle(DeleteMeterReadingCommand request, CancellationToken cancellationToken)
    {
        var meterReading = base._mapper.Map<MeterReading>(request);
        await base._repository.DeleteAsync(meterReading);
        meterReading.AddDomainEvent(new MeterReadingDeletedEvent(meterReading));
        await base._unitOfWork.Save(cancellationToken);
    }
}
