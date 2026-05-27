using FluentResults;

namespace phoenix_web_bff.Presentation.Common.ResultUtils.Errors;

public class GrpcError(string message) : Error(message);
