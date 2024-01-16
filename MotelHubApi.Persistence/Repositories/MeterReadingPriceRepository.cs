using System;

namespace MotelHubApi.Persistence;

public class MeterReadingPriceRepository : BaseRepository<MeterReadingPrice>, IMeterReadingPriceRepository
{
	public MeterReadingPriceRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

