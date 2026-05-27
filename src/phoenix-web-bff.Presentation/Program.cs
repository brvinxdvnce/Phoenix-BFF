using System.Reflection;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using phoenix_web_bff.Presentation.Common.Services.Implementations;
using phoenix_web_bff.Presentation.DependencyInjection;
using phoenix_web_bff.Presentation.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGrpcErrorHandler, GrpcErrorHandler>();

builder.AddGrpcClients();

builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.AddIncidentEndpoints();
app.AddMetricsEndpoints();
app.AddUnitsEndpoints();

app.Run();

//app.MapReverseProxy();

