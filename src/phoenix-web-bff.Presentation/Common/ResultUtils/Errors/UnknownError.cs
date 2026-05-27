using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class UnknownError(string message) : Error(message);
