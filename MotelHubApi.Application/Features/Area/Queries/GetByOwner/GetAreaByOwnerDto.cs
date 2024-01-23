using MediatR;

namespace MotelHubApi;

public class GetAreaByOwnerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
