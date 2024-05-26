using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;
public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
    {
    }
}
