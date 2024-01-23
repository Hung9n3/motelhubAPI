namespace MotelHubApi;

public interface IBillRepository : IBaseRepository<Bill>
{
    Task<IEnumerable<Bill>> GetByContract(int contractId);
    Task<IEnumerable<Bill>> GetByHostContract(int hostId);
    Task<IEnumerable<Bill>> GetByCustomerContract(int customerId);
}
