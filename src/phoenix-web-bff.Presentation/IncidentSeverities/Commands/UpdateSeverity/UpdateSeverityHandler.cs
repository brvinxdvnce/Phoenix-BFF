using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Commands.UpdateSeverity;

public class UpdateSeverityHandler(
    IGrpcErrorHandler grpcErrorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<UpdateSeverityCommand, Result<IncidentSeverityResponse>>
{
    public async Task<Result<IncidentSeverityResponse>> Handle(UpdateSeverityCommand request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() =>
            incidentServiceClient.UpdateSeverityAsync(request.Request, new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}