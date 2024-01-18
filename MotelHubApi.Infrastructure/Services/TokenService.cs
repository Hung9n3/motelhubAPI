using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace MotelHubApi.Infrastructure;

public class TokenService : ITokenService
{
    private readonly JwtConfig _jwtConfig;

    public TokenService(IOptions<JwtConfig> options)
    {
        this._jwtConfig = options.Value;
    }

    public Task<string> GetTokenAsync(User user, Claim[]? claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtConfig.SecretKey));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow + this._jwtConfig.ExpireDay,
            signingCredentials: signIn);

        var result = new JwtSecurityTokenHandler().WriteToken(token);
        return Task.FromResult(result);
    }
}

