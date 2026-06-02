namespace phoenix_web_bff.Presentation.Units.Dto;

public record UpdateUnitDto(
    string? Name,
    double? Severity,
    string[]? SubUnits
);
