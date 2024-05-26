using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
	public ContractRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

