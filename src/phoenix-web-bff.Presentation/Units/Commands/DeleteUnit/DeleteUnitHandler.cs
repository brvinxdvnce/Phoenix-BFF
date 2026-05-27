using FluentResults;
using Grpc.Core;
using MediatR;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.DeleteUnit;

public class DeleteUnitHandler(
    IGrpcErrorHandler grpcErrorHandler,
    UnitService.UnitServiceClient unitServiceClient
    ) : IRequestHandler<DeleteUnitCommand, Result<Empty>>
{
    public async Task<Result<Empty>> Handle(DeleteUnitCommand request, CancellationToken ct)
    {
        return await grpcErrorHandler.TryAsync(() =>
            unitServiceClient
                .DeleteUnitAsync(
                    new Id { Id_ = request.Id },
                    new CallOptions(cancellationToken:ct))
                .ResponseAsync);
    }
}