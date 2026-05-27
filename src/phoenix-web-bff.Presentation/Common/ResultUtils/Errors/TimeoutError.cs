using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class TimeoutError(string message) : Error(message);