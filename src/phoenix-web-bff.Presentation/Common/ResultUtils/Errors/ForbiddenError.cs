using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class ForbiddenError(string message) : Error(message);