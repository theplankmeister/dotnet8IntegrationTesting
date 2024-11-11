await PrepareHostBuilder().Build().RunAsync();
    
public partial class Program
{
     public static IHostBuilder PrepareHostBuilder() => 
        new HostBuilder()
            .ConfigureFunctionsWebApplication()
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationInsightsTelemetryWorkerService();
                services.ConfigureFunctionsApplicationInsights();

                services.AddTransient<ExampleService>();
            });
}
