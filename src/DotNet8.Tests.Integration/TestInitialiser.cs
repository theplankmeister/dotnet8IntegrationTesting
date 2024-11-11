namespace DotNet8.Tests.Integration;

public class TestInitialiser : IAsyncLifetime
{
    public IHost Host { get; }

    public TestInitialiser()
    {
        IHostBuilder hb = Program.PrepareHostBuilder();

        hb.ConfigureFunctionsWorkerDefaults()
        .ConfigureAppConfiguration(builder =>
            {
                IConfiguration config = new ConfigurationManager()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("test.settings.json", false, false)
                    .AddEnvironmentVariables()
                    .Build();

                builder.AddConfiguration(config);
            }
        )

        .ConfigureServices(b => { 
            b.AddSingleton<ExampleHandler>();
        });

        Host = hb.Build();
    }

    public async Task DisposeAsync()
    {
        await Host.StopAsync();
    }

    public async Task InitializeAsync()
    {
        await Host.StartAsync();
    }
}
