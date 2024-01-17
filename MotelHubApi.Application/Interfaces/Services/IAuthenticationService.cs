using System;
namespace MotelHubApi
{
	public interface IAuthenticationService
	{
		Task<string> Login(LoginDto dto);
		Task<User> Register(RegisterDto dto);
 	}
}

