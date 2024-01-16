using System;

namespace MotelHubApi.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
	public UserRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

