using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
	public ContractRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<Contract>> GetByCustomer(int customerId)
    {
        var result = await base.Entities.Where(x => x.CustomerId == customerId).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Contract>> GetByHost(int hostId)
    {
        var result = await base.Entities.Where(x => x.HostId == hostId).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Contract>> GetByRoom(int roomId)
    {
        var result = await base.Entities.Where(x => x.RoomId == roomId).ToListAsync();
        return result;
    }
}

