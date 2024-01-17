using System;
namespace MotelHubApi.Infrastructure;

public class JwtConfig
{
	public string SecretKey { get; set; } = string.Empty;
	public string ExpireDay { get; set; } = string.Empty;

}

