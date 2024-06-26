﻿using System;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MotelHubApi.WebApi;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
	private readonly IAuthenticationService _authenticationService;

	public AuthenticationController(IAuthenticationService authenticationService)
	{
		this._authenticationService = authenticationService;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterDto dto)
	{
        if (dto.Password.IsNullOrEmpty() || dto.Username.IsNullOrEmpty())
        {
           return BadRequest($"{nameof(dto.Password)} and {nameof(dto.Username)} can not empty");
        }
		var result = await _authenticationService.Register(dto);
		return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginDto dto)
    {        
        var result = await _authenticationService.Login(dto);
        return Ok(result);
    }
}

