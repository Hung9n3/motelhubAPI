namespace MotelHubApi;

public interface IPhotoRepository : IBaseRepository<Photo>
{
    Task<IEnumerable<Photo>> GetByUser(int userId);
    Task<IEnumerable<Photo>> GetByRoom(int roomId);
    Task<IEnumerable<Photo>> GetByMeterReading(int meterReadingId);
    Task<IEnumerable<Photo>> GetByContract(int contractId);
    Task<IEnumerable<Photo>> GetByArea(int areaId);
}
