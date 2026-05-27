using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Commands.CreateIncident;

public class CreateIncidentHandler(
    IGrpcErrorHandler grpcErrorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<CreateIncidentCommand, Result<IncidentResponse>>
{
    public async Task<Result<IncidentResponse>> Handle(
        CreateIncidentCommand request, 
        CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() => incidentServiceClient
            .CreateIncidentAsync(
                new CreateIncidentRequest(),
                new CallOptions(cancellationToken: ct))
            .ResponseAsync);
    }
}