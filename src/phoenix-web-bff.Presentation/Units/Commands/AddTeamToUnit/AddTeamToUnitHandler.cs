using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.AddTeamToUnit;

public class AddTeamToUnitHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient
    ) : IRequestHandler<AddTeamToUnitCommand, Result<UnitResponse>>
{
    public async Task<Result<UnitResponse>> Handle(AddTeamToUnitCommand request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() =>
            unitServiceClient
                .AddTeamToUnitAsync(
                    new AddTeamRequest() { TeamId = request.TeamId, UnitId = request.UnitId }, 
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}