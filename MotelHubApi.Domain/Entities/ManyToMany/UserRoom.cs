using System;
namespace MotelHubApi
{
	public class UserRoom : BaseEntity, IEntity
	{
		public int MemberId { get; set; }
		public int RoomId { get; set; }

		public User? Member { get; set; }
		public Room? Room { get; set; }
    }
}

