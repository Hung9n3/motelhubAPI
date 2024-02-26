using MotelHubApi.Persistence;

namespace MotelHubApi;

public class RatingAndReviewRepository : BaseRepository<RatingAndReview>, IRatingAndReviewRepository
{
    public RatingAndReviewRepository(MotelHubSqlServerDbContext dbContext) : base(dbContext)
    {
    }
}
