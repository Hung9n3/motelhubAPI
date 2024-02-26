namespace MotelHubApi;

public class RatingAndReview : BaseEntity
{
    public string? Subject { get; set; } = string.Empty;
    public string? Comment { get; set; } = string.Empty;
    public double? Rating { get; set; } 
    public int UserId { get; set; }
    public int RoomId { get; set; }

    public User? User { get; set; }
    public Room? Room { get; set; }
}
