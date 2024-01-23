using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class MeterReadingPriceRepository : BaseRepository<MeterReadingPrice>, IMeterReadingPriceRepository
{
	public MeterReadingPriceRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<MeterReadingPrice?> GetByPrice(decimal price)
    {
        var result = await base.Entities.FirstOrDefaultAsync(x => x.Price == price);
        return result;
    }
}

