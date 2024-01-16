using System;

namespace MotelHubApi.Persistence;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
	public RoleRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

