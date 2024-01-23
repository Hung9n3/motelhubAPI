using System;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class BillRepository : BaseRepository<Bill>, IBillRepository
{
	public BillRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<IEnumerable<Bill>> GetByContract(int contractId)
    {
        var result = await base.Entities.Where(x => x.ContractId == contractId).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Bill>> GetByCustomerContract(int customerId)
    {
        var result = await base.Entities.Where(x => x.Contract != null && x.Contract.CustomerId == customerId).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Bill>> GetByHostContract(int hostId)
    {
        var result = await base.Entities.Where(x => x.Contract != null && x.Contract.HostId == hostId).ToListAsync();
        return result;
    }
}

