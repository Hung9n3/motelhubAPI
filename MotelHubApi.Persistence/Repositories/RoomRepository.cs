using System;

namespace MotelHubApi.Persistence;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
	public RoomRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<Room>> GetByArea(int areaId)
    {
        var rooms = base.Entities.Where(x => x.AreaId == areaId).ToList();
        return rooms;
    }
}

