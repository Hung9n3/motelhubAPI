namespace MotelHubApi.Infrastructure;

public class ContractLogic : BaseLogic<Contract, IContractRepository>, IContractLogic
{
    public ContractLogic(IContractRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
