using System;
namespace MotelHubApi;

public record RegisterDto(string Fullname, string Phonenumber, string Address, string Username, string Password, int RoleId);

