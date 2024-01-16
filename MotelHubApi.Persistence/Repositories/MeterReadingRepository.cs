using System;

namespace MotelHubApi.Persistence;

public class AreaRepository : BaseRepository<Area>, IAreaRepository
{
	public AreaRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

