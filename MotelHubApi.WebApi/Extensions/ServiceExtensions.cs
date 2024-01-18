using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MotelHubApi.Infrastructure;
using System.Text;
using MotelHubApi.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace MotelHubApi.WebApi;

public static class ServiceExtensions
{
	public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
	{
        services.ConfigPolicy();
        services.ConfigAuth(configuration);
        services.ConfigIdentity();
    }

    #region Policy

    private static void ConfigPolicy(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("Basic", policy => policy.RequireRole("Basic"));
            options.AddPolicy("Basic", policy => policy.RequireRole("Basic"));
            options.AddPolicy("IsUser", policy => policy.RequireRole("Vip", "Basic"));
        });
    }

    #endregion

    #region Identity

    private static void ConfigIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 1;

            options.User.RequireUniqueEmail = false;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-+";
            options.SignIn.RequireConfirmedEmail = false;
        })
                .AddEntityFrameworkStores<MotelHubSqlServerDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();
    }
    #endregion

    #region ConfigAuth

    private static void ConfigAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;

            var jwtConfig = configuration.GetSection(nameof(JwtConfig)).Get<JwtConfig>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig!.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
            options.Events = new JwtBearerEvents
            {

                OnAuthenticationFailed = context =>
                {
                    // Custom logic when token authentication fails
                    // For example, you can log the error or handle it in a specific way
                    string authorizationHeader = context.Request.Headers["Authorization"];

                    if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
                    {
                        // Remove "Bearer " prefix to extract the token
                        string token = authorizationHeader.Substring(7);
                        var jwtHandler = new JwtSecurityTokenHandler();
                        var jwtToken = jwtHandler.ReadJwtToken(token);

                        var a = jwtToken.Payload;
                    }

                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    // Custom logic after the token is successfully validated
                    // Access the validated claims using context.Principal.Claims
                    var dbContext = context.HttpContext.RequestServices.GetRequiredService<MotelHubSqlServerDbContext>();
                    var userId = context.Principal?.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                    if (userId.IsNullOrEmpty() || !int.TryParse(userId, out var intId))
                    {
                        return Task.CompletedTask;
                    }
                    var role = dbContext.Users.Where(x => x.Id == intId).Include(x => x.Role).FirstOrDefault()?.Role;
                    if (role is null)
                    {
                        return Task.CompletedTask;
                    }
                    var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                    var claim = new Claim(ClaimTypes.Role, role.Name);
                    claimsIdentity?.AddClaim(claim);
                    // Perform additional processing or checks based on the claims
                    // For example, you can add custom authorization logic or enrich the current user's identity
                    return Task.CompletedTask;
                }
            };
        });
    }
    #endregion
}

