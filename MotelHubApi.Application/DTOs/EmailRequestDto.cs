using System;
namespace MotelHubApi;

public record EmailRequestDto(string Subject, string Body, string From, string To);

