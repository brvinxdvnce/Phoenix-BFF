using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class ServiceUnavailableError(string message) : Error(message);
