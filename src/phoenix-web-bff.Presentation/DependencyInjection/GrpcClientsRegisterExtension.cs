using Grpc.Net.Client;
using Phoenix;

namespace phoenix_web_bff.Presentation.DependencyInjection;

public static class GrpcClientsRegisterExtension
{
    public static WebApplicationBuilder AddGrpcClients(this WebApplicationBuilder builder)
    {
        var coreChannel = GrpcChannel.ForAddress(builder.Configuration["Grpc:CoreAddress"]!);
        var sentryChannel = GrpcChannel.ForAddress(builder.Configuration["Grpc:SentryAddress"]!);

        builder.Services.AddSingleton(new IncidentService.IncidentServiceClient(coreChannel));
        builder.Services.AddSingleton(new UnitService.UnitServiceClient(coreChannel));
        builder.Services.AddSingleton(new MetricService.MetricServiceClient(sentryChannel));
        
        return builder;
    }
}