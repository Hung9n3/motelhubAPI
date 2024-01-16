using System;

namespace MotelHubApi.Persistence;

public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
{
	public PhotoRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

