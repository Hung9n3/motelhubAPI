namespace MotelHubApi;

public interface IRatingAndReviewRepository : IBaseRepository<RatingAndReview>
{
    Task<List<RatingAndReview>> GetByRoom(PagingOptions pagingOptions, int roomId);
}
