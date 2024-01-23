using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
{
	public PhotoRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<Photo>> GetByArea(int areaId)
    {
        return await base.Entities.Where(x => x.AreaId == areaId).ToListAsync();
    }

    public async Task<IEnumerable<Photo>> GetByContract(int contractId)
    {
        return await base.Entities.Where(x => x.ContractId == contractId).ToListAsync();
    }

    public async Task<IEnumerable<Photo>> GetByMeterReading(int meterReadingId)
    {
        return await base.Entities.Where(x => x.MeterReadingId == meterReadingId).ToListAsync();
    }

    public async Task<IEnumerable<Photo>> GetByRoom(int roomId)
    {
        return await base.Entities.Where(x => x.RoomId == roomId).ToListAsync();
    }

    public async Task<IEnumerable<Photo>> GetByUser(int userId)
    {
        return await base.Entities.Where(x => x.UserId == userId).ToListAsync();
    }
}

