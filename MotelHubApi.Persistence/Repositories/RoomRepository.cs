using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
	public RoomRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<Room>> GetByArea(int? areaId)
    {
        var rooms = await base.Entities.Where(x => x.AreaId == areaId).Include(x => x.Owner).ToListAsync();
        return rooms;
    }
}

