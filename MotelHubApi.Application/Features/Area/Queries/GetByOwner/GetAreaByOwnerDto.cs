using MediatR;

namespace MotelHubApi;

public class GetAreaByOwnerDto : BaseAreaModel
{
    public int EmptyRoom { get; set; }
    public int RoomCount { get; set; }
}
