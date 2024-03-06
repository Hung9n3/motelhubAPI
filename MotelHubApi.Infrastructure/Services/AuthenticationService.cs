using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MotelHubApi.Infrastructure;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthenticationService(UserManager<User> userManager, ITokenService tokenService, IMapper mapper)
	{
        this._userManager = userManager;
        this._tokenService = tokenService;
        this._mapper = mapper;
	}

    public async Task<string> Login(LoginDto dto)
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        var user = default(User);
        var isEmail = Regex.IsMatch(pattern, dto.UsernameOrEmail);
        if(isEmail)
        {
            user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
        }
        else
        {
            user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
        }
        if(user is null)
        {
            return null;
        }
        var passwordCheck = await _userManager.CheckPasswordAsync(user, dto.Password);
        if(!passwordCheck)
        {
            return null;
        }

        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("DisplayName", user.Fullname),
                        new Claim("Email", user.Email ?? string.Empty),
                    };
        var token = await this._tokenService.GetTokenAsync(user, claims);
        return token;
    }

    public async Task<User> Register(RegisterDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var result = await _userManager.CreateAsync(user, dto.Password);
        if(result.Succeeded)
        {
            return user;
        }
        else
        {
            var error = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
            throw new Exception($"Unable to create user {user.UserName}. Result details: {result}");
        }
    }
}

