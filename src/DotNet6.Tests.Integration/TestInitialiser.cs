using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;

namespace DotNet6.Tests.Integration;

public class TestInitialiser : IAsyncLifetime
{
    public IServiceProvider ServiceProvider { get; private set; }

    private readonly IHost _host;

    /// <summary>
    /// Prepares the DI container for the integration testing entry point
    /// </summary>
    public TestInitialiser()
    {

        _host = new HostBuilder()
            .ConfigureAppConfiguration(app =>
            {
                IConfiguration config = new ConfigurationManager()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("test.settings.json", false, false)
                    .AddEnvironmentVariables()
                    .Build();

                app.AddConfiguration(config);
            })
            .ConfigureWebJobs((context, builder) =>
            {
                WebJobsBuilderContext ctx = new()
                {
                    Configuration = context.Configuration
                };
                builder.UseWebJobsStartup(typeof(TestStartup), ctx, NullLoggerFactory.Instance);
            })
            .ConfigureServices(b =>
            { 
                b.AddTransient<ExampleHandler>();
            })
            .Build();

        ServiceProvider = _host.Services;
    }

    public async Task DisposeAsync()
    {
        await _host.StopAsync();
    }

    public async Task InitializeAsync()
    {
        await _host.StartAsync();
    }
}
