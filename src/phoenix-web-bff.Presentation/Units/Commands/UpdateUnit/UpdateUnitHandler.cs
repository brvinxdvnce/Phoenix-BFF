using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.UpdateUnit;

public class UpdateUnitHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient) : IRequestHandler<UpdateUnitCommand, Result<UnitResponse>>
{
    public async Task<Result<UnitResponse>> Handle(UpdateUnitCommand command, CancellationToken ct)
    {
        // I hate grpc with all my soul.

        var newName = new NewValue() {Value = "", HasNewValue = false};
        
        if (command.UpdateUnitDto.Name is not null) {
            newName = new NewValue() { Value = command.UpdateUnitDto.Name, HasNewValue = true, };
        }

        var request = new UpdateUnitRequest()
        {
            Id = command.UnitId,
            Name = newName,
        };
        
        if (command.UpdateUnitDto.Severity.HasValue)
            request.Severity = command.UpdateUnitDto.Severity.Value;

        if (command.UpdateUnitDto.SubUnits is not null)
            request.SubUnitsIds.AddRange(command.UpdateUnitDto.SubUnits);

        return await grpcErrorHandler.TryAsync(() =>
            unitServiceClient
                .UpdateUnitAsync(
                    request,
                    new CallOptions(cancellationToken: ct))
                .ResponseAsync);
    }
}