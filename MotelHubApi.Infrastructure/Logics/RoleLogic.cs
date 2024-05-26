namespace MotelHubApi.Infrastructure;

public class RoleLogic : BaseLogic<Role, IRoleRepository>, IRoleLogic
{
    public RoleLogic(IRoleRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
