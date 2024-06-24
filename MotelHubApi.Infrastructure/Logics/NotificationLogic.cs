using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Infrastructure;

public class NotificationLogic : BaseLogic<Notification, INotificationRepository>, INotificationLogic
{
    public NotificationLogic(INotificationRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
