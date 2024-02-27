using AutoMapper;
using FluentValidation;
using MediatR;

namespace MotelHubApi;
public class CreateAppointmentCommand : BaseAppointmentModel, IRequest
{
}

internal class AppointmentCreateCommandHandler : BaseHandler<Appointment, CreateAppointmentCommand, IAppointmentRepository>
{
    private readonly IValidator<CreateAppointmentCommand> _validator;
    public AppointmentCreateCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository, IMapper mapper, IValidator<CreateAppointmentCommand> validator) 
        : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            string message = string.Join(", ", validationResult.Errors.Select(a => a.ErrorMessage));
            throw new Exception($"{message}");
        }

        var appointment = _mapper.Map<Appointment>(request);
        var result = await _repository.AddAsync(appointment);
        appointment.AddDomainEvent(new AppointmentCreatedEvent(appointment));
        await _unitOfWork.Save(cancellationToken);
    }
}
