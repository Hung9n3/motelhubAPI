namespace MotelHubApi.Infrastructure;
public class ElasticsearchConfig
{
    public string Url { get; set; } = string.Empty;
    public string DefaultIndex { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Certificate { get; set; } = string.Empty;
}
