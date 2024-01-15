using System;
namespace MotelHubApi;

public interface IEmailService
{
    Task SendAsync(EmailRequestDto request);
}

