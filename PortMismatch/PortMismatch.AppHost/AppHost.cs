var builder = DistributedApplication.CreateBuilder(args);

var temporalServer = builder.AddTemporalServerContainer("testWithPorts", temporal => temporal
    .WithPort(1234)
    .WithHttpPort(2345)
    .WithMetricsPort(3456)
    .WithUiPort(4567)
    .WithNamespace("testing")
    .WithLogLevel(InfinityFlow.Aspire.Temporal.LogLevel.Info)
);  //These port bindings do not tie to the server, but do tie to the dashboard.

var temporalServerTest = builder.AddTemporalServerContainer("testDefaultPorts", temporal => temporal
    .WithNamespace("testing")
    .WithLogLevel(InfinityFlow.Aspire.Temporal.LogLevel.Info)
);  //The default ports tie to the server and the dashboard.

builder.Build().Run();
