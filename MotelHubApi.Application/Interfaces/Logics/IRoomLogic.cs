using Microsoft.EntityFrameworkCore;

namespace MotelHubApi;

public interface IRoomLogic : IBaseLogic<Room>
{
    Task<List<Room>> Search(SearchOptions options);
    Task Sync();
}
