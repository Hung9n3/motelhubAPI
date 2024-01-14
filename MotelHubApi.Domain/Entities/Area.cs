﻿using System;
namespace MotelHubApi;

public class Area : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Address { get; set; } = string.Empty;
	public double? Longtitude { get; set; }
	public double? Latitude { get; set; }
	public int HostId { get; set; }

	public User Host { get; set; } = new();

	public Area()
	{
	}
}

