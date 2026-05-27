using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.CreateUnit;

public class CreateUnitHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient
    ) : IRequestHandler<CreateUnitCommand, Result<UnitResponse>>
{
    public async Task<Result<UnitResponse>> Handle(CreateUnitCommand command, CancellationToken ct)
    {
        var createUnitRequest = new CreateUnitRequest
        {
            Name = command.Name,
            Description = command.Description,
            Severity = command.Severity,
            Type = command.Type,
            ParentId = command.ParentId
        };

        return await grpcErrorHandler.TryAsync(() =>
            unitServiceClient
                .CreateUnitAsync(
                    createUnitRequest,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}