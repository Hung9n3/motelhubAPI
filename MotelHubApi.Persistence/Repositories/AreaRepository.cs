using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class AreaRepository : BaseRepository<Area>, IAreaRepository
{
	public AreaRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<Area>> GetByUser(int userId)
    {
        var result = await base.Entities.Where(x => x.HostId == userId).Include(x => x.Rooms).ToListAsync();
        return result;
    }
}

