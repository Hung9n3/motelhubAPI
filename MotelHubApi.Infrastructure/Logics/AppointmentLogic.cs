using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi.Infrastructure;
public class AppointmentLogic : BaseLogic<Appointment, IAppointmentRepository>, IAppointmentLogic
{
    public AppointmentLogic(IAppointmentRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
