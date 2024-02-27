using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class RepositoryContext
{
    public RepositoryContext(
        IAreaRepository area, 
        IRoomRepository room, 
        IMeterReadingRepository meterReading, 
        IPhotoRepository photo, 
        IBillRepository bill, 
        IContractRepository contract, 
        IUserRepository user, 
        IRoleRepository role, 
        IMeterReadingPriceRepository meterReadingPrice)
    {
        this.Photo = photo;
        this.MeterReadingPrice = meterReadingPrice;
        this.Area = area;
        this.Role = role;
        this.Room = room;
        this.User = user;
        this.MeterReading = meterReading;
        this.Bill = bill;
        this.Contract = contract;
    }

    public IAreaRepository Area { get; }
    public IRoomRepository Room { get; }
    public IMeterReadingRepository MeterReading { get; }
    public IPhotoRepository Photo { get; }
    public IBillRepository Bill { get; }
    public IContractRepository Contract { get; }
    public IUserRepository User { get; }
    public IRoleRepository Role { get; }
    public IMeterReadingPriceRepository MeterReadingPrice { get; }
}
