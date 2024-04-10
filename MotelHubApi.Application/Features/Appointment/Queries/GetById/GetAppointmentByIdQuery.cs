using AutoMapper;
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
    private readonly IElasticsearchService elasticsearchService;
    public GetAppointmentByIdHandler(IUnitOfWork unitOfWork, IAppointmentRepository repository, IMapper mapper, IElasticsearchService elasticsearchService)
        : base(unitOfWork, repository, mapper)
    {
        this.elasticsearchService = elasticsearchService;
    }

    public override async Task<GetAppointmentByIdDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var a = elasticsearchService.IndexDocument<Room>(new Room());
        var dbResult = await base._repository.GetByIdAsync(request.Id, x => x.Host, x => x.Customer, x => x.Room);
        var result = base._mapper.Map<GetAppointmentByIdDto>(dbResult);
        return result;
    }
}
