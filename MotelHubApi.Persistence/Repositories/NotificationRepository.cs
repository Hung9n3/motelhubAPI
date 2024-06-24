namespace MotelHubApi.Persistence;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
	public NotificationRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

