using FluentResults;
using MediatR;
using Phoenix;

namespace phoenix_web_bff.Presentation.Units.Commands.DeleteUnit;

public record DeleteUnitCommand(string Id) : IRequest<Result<Empty>>;