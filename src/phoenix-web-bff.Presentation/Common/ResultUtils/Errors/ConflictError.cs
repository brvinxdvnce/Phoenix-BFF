using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class ConflictError(string message) : Error(message);