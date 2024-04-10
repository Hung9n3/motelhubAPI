namespace MotelHubApi;
public class PagingOptions
{
    public int LastId { get; set; }
    public int PageSize { get; set; } = 10;
    public int PageCount { get; set; }
}
