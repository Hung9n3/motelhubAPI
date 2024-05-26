namespace MotelHubApi.Infrastructure;

public class BillLogic : BaseLogic<Bill, IBillRepository>, IBillLogic
{
    public BillLogic(IBillRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
