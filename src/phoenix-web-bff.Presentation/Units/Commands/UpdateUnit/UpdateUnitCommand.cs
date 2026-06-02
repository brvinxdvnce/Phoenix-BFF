using FluentResults;
using MediatR;
using phoenix_web_bff.Presentation.Units.Dto;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.UpdateUnit;

public record UpdateUnitCommand(string UnitId, UpdateUnitDto UpdateUnitDto) 
    : IRequest<Result<UnitResponse>>;