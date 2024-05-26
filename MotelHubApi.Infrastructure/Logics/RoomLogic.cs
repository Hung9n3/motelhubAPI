using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Infrastructure;

public class RoomLogic : BaseLogic<Room, IRoomRepository>, IRoomLogic
{
    public RoomLogic(IRoomRepository repository, RepositoryContext repositoryContext) : base(repository, repositoryContext)
    {
    }
}
