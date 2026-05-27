using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class NotFoundError(string message) : Error(message);