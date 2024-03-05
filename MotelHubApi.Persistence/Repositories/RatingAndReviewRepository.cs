using Microsoft.EntityFrameworkCore;
using MotelHubApi.Persistence;

namespace MotelHubApi;

public class RatingAndReviewRepository : BaseRepository<RatingAndReview>, IRatingAndReviewRepository
{
    public RatingAndReviewRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RatingAndReview>> GetByRoom(PagingOptions pagingOptions, int roomId)
    {
        var dbResult = await base._dbContext.RatingAndReviews.Where(x => x.Id > pagingOptions.LastId && x.RoomId == roomId).Take(pagingOptions.PageSize).ToListAsync();
        return dbResult;
    }
}
