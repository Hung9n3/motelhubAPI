using Microsoft.EntityFrameworkCore;

namespace MotelHubApi;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<IEnumerable<Room>> GetByArea(int? areaId);
    Task<IEnumerable<Room>> GetByOwner(int? ownerId);
    Task<IEnumerable<Room>> GetLivingRoom(int memberId);
}
