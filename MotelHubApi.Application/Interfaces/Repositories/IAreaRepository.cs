namespace MotelHubApi;

public interface IAreaRepository : IBaseRepository<Area>
{
    Task<IEnumerable<Area>> GetByUser(int userId);
}
