using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Queries.GetIncidents;

public class GetIncidentsHandler(
    IGrpcErrorHandler grpcErrorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<GetIncidentsQuery, Result<IncidentListResponse>>
{
    public async Task<Result<IncidentListResponse>> Handle(
        GetIncidentsQuery request,
        CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() => 
            incidentServiceClient
                .GetIncidentsAsync(
                    new Empty(),
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}