using System;
namespace MotelHubApi;

public abstract class BaseAreaModel
{
	public int HostId { get; set; }
	public string Address { get; set; } = string.Empty;
}

