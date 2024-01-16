using System;
namespace MotelHubApi;

public class GetRoomsByAreaDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public double Acreage { get; set; }
}

