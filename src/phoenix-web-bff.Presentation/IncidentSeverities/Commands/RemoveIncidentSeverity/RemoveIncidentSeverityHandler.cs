using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Commands.RemoveIncidentSeverity;

public class RemoveIncidentSeverityHandler(
    IGrpcErrorHandler errorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
) : IRequestHandler<RemoveIncidentSeverityCommand, Result<Empty>>
{
    public async Task<Result<Empty>> Handle(RemoveIncidentSeverityCommand request, CancellationToken ct)
    {
        return await errorHandler.TryAsync(() => 
            incidentServiceClient
                .RemoveIncidentSeverityAsync(
                    request.Id,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}