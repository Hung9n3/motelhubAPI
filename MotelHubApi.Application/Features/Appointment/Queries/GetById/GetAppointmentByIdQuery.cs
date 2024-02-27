﻿using AutoMapper;
using MediatR;

namespace MotelHubApi;
public class GetAppointmentByIdQuery : BaseAppointmentModel, IRequest<GetAppointmentByIdDto>
{
    public GetAppointmentByIdQuery(int id)
    {
        base.Id = id;
    }
}

internal class GetAppointmentByIdHandler : BaseHandler<Appointment, GetAppointmentByIdQuery, IAppointmentRepository, GetAppointmentByIdDto>
{
    public GetAppointmentByIdHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository, IMapper mapper) 
        : base(unitOfWork, repository, mapper)
    {
    }

    public override async Task<GetAppointmentByIdDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await base._repository.GetByIdAsync(request.Id, x => x.Host, x => x.Customer, x => x.Room);
        var result = base._mapper.Map<GetAppointmentByIdDto>(dbResult);
        return result;
    }
}