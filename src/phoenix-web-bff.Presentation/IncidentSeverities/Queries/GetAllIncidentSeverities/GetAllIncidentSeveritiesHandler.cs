using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Queries.GetAllIncidentSeverities;

public class GetAllIncidentSeveritiesHandler(
    IGrpcErrorHandler errorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<GetAllIncidentSeveritiesQuery, Result<SeveritiesListResponse>>
{
    public async Task<Result<SeveritiesListResponse>> Handle(GetAllIncidentSeveritiesQuery request, CancellationToken ct)
    {
        return await errorHandler.TryAsync(() =>
            incidentServiceClient
                .GetAllIncidentSeveritiesAsync(
                    new Empty(), 
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}