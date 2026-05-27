using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class InternalError(string message) : Error(message);
