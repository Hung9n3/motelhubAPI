using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
	public RoomRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

