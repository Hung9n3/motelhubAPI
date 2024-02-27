using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MotelHubApi;

public class DeleteAppointmentCommand : BaseAppointmentModel, IRequest
{
}

public class DeleteAppointmentCommandHandler : BaseHandler<Appointment, DeleteAppointmentCommand, IAppointmentRepository>
{
    public DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository, IMapper mapper)
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = base._mapper.Map<Appointment>(request);
        await base._repository.DeleteAsync(appointment);
        appointment.AddDomainEvent(new AppointmentDeletedEvent(appointment));
        await base._unitOfWork.Save(cancellationToken);
    }
}
