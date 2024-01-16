namespace MotelHubApi;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<IEnumerable<Room>> GetByArea(int? areaId);
}
