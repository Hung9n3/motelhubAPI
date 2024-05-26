namespace MotelHubApi.Infrastructure;

public class UserLogic : BaseLogic<User, IUserRepository>, IUserLogic
{
    public UserLogic(IUserRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
