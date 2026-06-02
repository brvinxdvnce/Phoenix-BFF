using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Commands.CreateIncidentSeverity;

public class CreateIncidentSeverityHandler (
    IGrpcErrorHandler errorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<CreateIncidentSeverityCommand, Result<IncidentSeverityResponse>>
{
    public async Task<Result<IncidentSeverityResponse>> Handle(
        CreateIncidentSeverityCommand request,
        CancellationToken ct)
    {
        return await errorHandler.TryAsync(() =>
            incidentServiceClient
                .CreateIncidentSeverityAsync(
                    request.Message,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}