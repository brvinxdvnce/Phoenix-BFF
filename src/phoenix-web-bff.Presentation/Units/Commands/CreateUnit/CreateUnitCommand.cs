using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.CreateUnit;

public record CreateUnitCommand(
    string Name,
    string Description,
    double Severity,
    string Type,
    string ParentId
    ) : IRequest<Result<UnitResponse>>;