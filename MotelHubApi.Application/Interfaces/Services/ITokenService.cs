using System;
using System.Security.Claims;

namespace MotelHubApi;

public interface ITokenService
{
    Task<string> GetTokenAsync(User user, Claim[]? claims);
}

