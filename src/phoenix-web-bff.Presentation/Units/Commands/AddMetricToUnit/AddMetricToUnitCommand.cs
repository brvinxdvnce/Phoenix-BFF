using FluentResults;
using MediatR;
using phoenix_web_bff.Presentation.Units.Dto;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.AddMetricToUnit;

public record AddMetricToUnitCommand(string UnitId, AddMetricToUnitDto MetricToUnitDto)
    : IRequest<Result<Empty>>;