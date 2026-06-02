using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Commands.UpdateSeverity;

public record UpdateSeverityCommand(UpdateIncidentSeverityCoefficientRequest Request) 
    : IRequest<Result<IncidentSeverityResponse>>;