namespace MotelHubApi;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }

    public BaseEntity()
    {
        CreateAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
        IsActive = true;
    }
}

