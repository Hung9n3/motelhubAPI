using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;
public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<Appointment?> GetByIdAsync(int id, params Expression<Func<Appointment, object>>[] selectors)
    {
        var result =  await base.Entities.Where(x => x.Id == id)
            .Include(x => x.Host)
            .Include(x => x.Customer
            ).Include(x => x.Room)
            .FirstOrDefaultAsync();
        if(result != null && result.Room != null)
        {
            result.Room.Area = await base._dbContext.Areas.FirstOrDefaultAsync(x => x.Id == result.Room.AreaId);
        }

        return result;
    }
}
