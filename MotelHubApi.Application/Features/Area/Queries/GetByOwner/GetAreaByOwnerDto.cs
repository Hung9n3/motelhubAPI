using MediatR;

namespace MotelHubApi;

public class GetAreaByOwnerDto : BaseAreaModel
{
    public int RoomCount { get; set; }
}
