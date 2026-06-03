using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using phoenix_web_bff.Presentation.Common.Services.Abstractions;
using phoenix_web_bff.Presentation.Common.Services.Implementations;
using phoenix_web_bff.Presentation.DependencyInjection;
using phoenix_web_bff.Presentation.Endpoints;
using phoenix_web_bff.Presentation.Middleware;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGrpcErrorHandler, GrpcErrorHandler>();

//builder.AddConfiguration();

builder.AddGrpcClients();

builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.UseMiddleware<ExceptionHandleMiddleware>();

//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.MapScalarApiReference();
//}

app.UseHttpsRedirection();

//app.AddAuthEndpoints();
app.AddIncidentEndpoints();
app.AddIncidentSeverityEndpoints();
app.AddMetricsEndpoints();
app.AddUnitsEndpoints();

app.Run();

//app.MapReverseProxy();
