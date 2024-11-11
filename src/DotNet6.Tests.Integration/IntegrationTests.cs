using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DotNet6.Tests.Integration;

[Collection(nameof(IntegrationTestsCollection))]
public class IntegrationTests : IClassFixture<TestStartup>, IAsyncLifetime
{
    private readonly ExampleHandler _handler;

    private readonly IServiceProvider _services;

    public IntegrationTests(TestInitialiser testIniter)
    {
        _services = testIniter.ServiceProvider;

        _handler = _services.GetService<ExampleHandler>()!;
    }

    [Fact]
    public void TestExampleEndpoint()
    {
        HttpRequest req = Substitute.ForPartsOf<HttpRequest>();

        IActionResult response = _handler.ExampleEndpoint(req);

        response.Should().BeOfType<OkObjectResult>();
        response.As<OkObjectResult>().Value.Should().BeOfType<string>();
        response.As<OkObjectResult>().Value.As<string>().Should().Be("This is the value of the config setting 'MySetting': FROM TEST");
    }

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await Task.CompletedTask;
    }
}

public class TestStartup : Startup
{
    /// <summary>
    /// Configures DI for the SUT, and then adds/overrides the necessary values to ensure the correct instances are injected for testing
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(IFunctionsHostBuilder builder)
    {
        base.Configure(builder);

        IConfiguration config = builder.GetContext().Configuration;

    }
}
