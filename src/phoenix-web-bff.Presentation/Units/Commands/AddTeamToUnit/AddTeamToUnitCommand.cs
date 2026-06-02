using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.AddTeamToUnit;

public record AddTeamToUnitCommand(string UnitId, string TeamId) : IRequest<Result<UnitResponse>>;