
namespace MotelHubApi;
/// <summary>
/// contains SearchQueries, ValueFilters, RangeFilters and PagingOptions
/// </summary>
public class SearchOptions
{
    /// <summary>
    /// contains search texts
    /// </summary>
    public List<SearchQuery> SearchQueries { get; set; } = new List<SearchQuery>();
    /// <summary>
    /// contains  equal filters search
    /// </summary>
    public List<ValueFilter> ValueFilters { get; set; } = new();
    /// <summary>
    /// contains from - to filters
    /// </summary>
    public List<RangeFilter> RangeFilters { get; set; } = new();
    public PagingOptions PagingOptions { get; set; } = new();
}
