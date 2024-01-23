namespace MotelHubApi;

public interface IMeterReadingPriceRepository : IBaseRepository<MeterReadingPrice>
{
    Task<MeterReadingPrice?> GetByPrice(decimal price);
}
