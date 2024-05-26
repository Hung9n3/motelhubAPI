namespace MotelHubApi.Infrastructure;

public class AreaLogic : BaseLogic<Area, IAreaRepository>, IAreaLogic
{
    public AreaLogic(IAreaRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
