namespace MotelHubApi;

public interface IContractRepository : IBaseRepository<Contract>
{
    Task<IEnumerable<Contract>> GetByRoom(int roomId);
    Task<IEnumerable<Contract>> GetByHost(int hostId);
    Task<IEnumerable<Contract>> GetByCustomer(int customerId);
}
