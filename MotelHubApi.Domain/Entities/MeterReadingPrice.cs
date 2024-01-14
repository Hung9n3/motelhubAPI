namespace MotelHubApi;

public class MeterReadingPrice : BaseEntity
{
    public int Price { get; set; }
    public MeterReadingType Type { get; set; }
}
