using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.IncidentSeverities.Commands.RemoveIncidentSeverity;

public record RemoveIncidentSeverityCommand(Id Id) : IRequest<Result<Empty>>;