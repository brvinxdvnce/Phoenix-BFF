using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Queries.GetIncident;

public class GetIncidentHandler(
    IGrpcErrorHandler grpcErrorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<GetIncidentQuery, Result<IncidentResponse>>
{
    public async Task<Result<IncidentResponse>> Handle(
        GetIncidentQuery request,
        CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() => 
            incidentServiceClient
                .GetIncidentAsync(
                    new Id { Id_ = request.IncidentId },
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}