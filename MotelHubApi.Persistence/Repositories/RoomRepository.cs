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

    public async Task<IEnumerable<Room>> GetByOwner(int? ownerId)
    {
        return await base.Entities.Where(x => x.OwnerId == ownerId).ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetLivingRoom(int memberId)
    {
        return await base.Entities.Where(x => x.Members.Any(x => x.Id == memberId)).ToListAsync();
    }
}

