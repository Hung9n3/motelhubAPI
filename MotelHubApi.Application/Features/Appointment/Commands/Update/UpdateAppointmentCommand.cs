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

public class UpdateAppointmentCommand : BaseAppointmentModel, IRequest
{
    public List<BasePhotoModel> Photos { get; set; } = new List<BasePhotoModel>();
}

public class UpdateAppointmentCommandHandler : BaseHandler<Appointment, UpdateAppointmentCommand, IAppointmentRepository>
{
    IValidator<UpdateAppointmentCommand> _validator;
    public UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository, IMapper mapper, IValidator<UpdateAppointmentCommand> validator) : base(unitOfWork, repository, mapper)
    {
        this._validator = validator;
    }

    public override async Task Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = this._validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exception($"{validationResult.Errors}");
        }
        var dbResult = await base._repository.GetByIdAsync(
            request.Id);
        if(dbResult is null)
        {
            throw new KeyNotFoundException();
        }
        base._mapper.Map(request, dbResult);
        dbResult.AddDomainEvent(new AppointmentUpdatedEvent(dbResult));
        await this._unitOfWork.Save(cancellationToken);
    }
}
