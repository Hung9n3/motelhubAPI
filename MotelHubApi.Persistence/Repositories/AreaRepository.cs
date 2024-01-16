using System;

namespace MotelHubApi.Persistence;

public class MeterReadingRepository : BaseRepository<MeterReading>, IMeterReadingRepository
{
	public MeterReadingRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

