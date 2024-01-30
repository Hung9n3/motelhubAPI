namespace MotelHubApi;

public class MeterReadingPrice : BaseEntity
{
    public decimal Price { get; set; }
    public MeterReadingType Type { get; set; }
}
