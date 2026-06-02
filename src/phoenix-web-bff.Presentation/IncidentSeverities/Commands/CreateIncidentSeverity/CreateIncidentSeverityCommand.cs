using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Commands.CreateIncidentSeverity;

public record CreateIncidentSeverityCommand(CreateIncidentSeverityMessage Message) 
    : IRequest<Result<IncidentSeverityResponse>>;