using System;
namespace MotelHubApi;

public class RoomCreatedEvent : BaseEvent
{
	public Room Room;
	public RoomCreatedEvent(Room room)
	{
		this.Room = room;
	}
}

