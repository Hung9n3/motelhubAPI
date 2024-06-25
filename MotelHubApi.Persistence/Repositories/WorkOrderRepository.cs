using System;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class WorkOrderRepository : BaseRepository<WorkOrder>, IWorkOrderRepository
{
	public WorkOrderRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
	{
	}
}

