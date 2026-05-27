using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class UnauthorizedError(string message) : Error(message);
