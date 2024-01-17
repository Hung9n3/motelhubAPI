using System;
namespace MotelHubApi.Infrastructure;

public class EmailConfig
{
	public string EmailHost { get; set; } = string.Empty;
	public string EmailUsername { get; set; } = string.Empty;
	public string AppPassword { get; set; } = string.Empty;
	public string Port { get; set; } = string.Empty;
}

