using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class MeterReadingRepository : BaseRepository<MeterReading>, IMeterReadingRepository
{
	public MeterReadingRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<MeterReading>> GetByPeriod(DateTime from, DateTime to)
    {
        var result = await base.Entities.Where(x => x.From >= from  && x.To <= to).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<MeterReading>> GetByRoom(int roomId)
    {
        var result = await base.Entities.Where(x => x.RoomId == roomId).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<MeterReading>> GetByUser(int ownerId)
    {
        var result = await base.Entities.Where(x => x.OwnerId == ownerId).ToListAsync();
        return result;
    }
}

