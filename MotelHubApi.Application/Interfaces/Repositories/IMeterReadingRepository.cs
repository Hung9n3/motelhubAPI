namespace MotelHubApi;

public interface IMeterReadingRepository : IBaseRepository<MeterReading>
{
    Task<IEnumerable<MeterReading>> GetByRoom(int roomId);
    Task<IEnumerable<MeterReading>> GetByRoomAndOwner(int roomId, int ownerId);
    Task<IEnumerable<MeterReading>> GetByUser(int ownerId);
    Task<IEnumerable<MeterReading>> GetByPeriod(DateTime from, DateTime to);
}
