using System;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class BillRepository : BaseRepository<Bill>, IBillRepository
{
	public BillRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

