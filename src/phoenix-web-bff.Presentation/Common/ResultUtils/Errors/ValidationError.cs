using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class ValidationError(string message) : Error(message);