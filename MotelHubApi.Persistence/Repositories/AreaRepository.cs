using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class AreaRepository : BaseRepository<Area>, IAreaRepository
{
	public AreaRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

