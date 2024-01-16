using System;

namespace MotelHubApi.Persistence;

public class BillRepository : BaseRepository<Bill>, IBillRepository
{
	public BillRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

