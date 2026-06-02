using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Incidents.Commands.CreateIncidentGroupGroup;

public class CreateIncidentGroupHandler (
    IGrpcErrorHandler grpcErrorHandler,
    IncidentService.IncidentServiceClient incidentServiceClient
    ) : IRequestHandler<CreateIncidentGroupCommand, Result<IncidentGroupResponse>>
{
    public async Task<Result<IncidentGroupResponse>> Handle(CreateIncidentGroupCommand request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() => 
            incidentServiceClient.CreateIncidentGroupAsync(
                    request.Request,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}