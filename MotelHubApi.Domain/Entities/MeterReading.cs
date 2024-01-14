﻿using System;
namespace MotelHubApi;

public class MeterReading : BaseEntity
{
	public string? Title { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
	public double LastMonth { get; set; }
	public double ThisMonth { get; set; }
	public double Value { get; set; }
	public MeterReadingType Type { get; set; }
	public int OwnerId { get; set; }
	public string? OwnerPhone { get; set; }
	public string? OwnerName { get; set; }
	public int RoomId { get; set; }
	public string? RoomName { get; set; }
	public Room Room { get; set; } = new();
	public User User { get; set; } = new();

	public MeterReading()
	{
	}
}

