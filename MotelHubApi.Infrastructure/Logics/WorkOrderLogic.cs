namespace MotelHubApi.Infrastructure;

public class WorkOrderLogic : BaseLogic<WorkOrder, IWorkOrderRepository>, IWorkOrderLogic
{
    public WorkOrderLogic(IWorkOrderRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
