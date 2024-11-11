namespace DotNet8.Tests.Integration;

[Collection(nameof(IntegrationTestsCollection))]
public class IntegrationTests
{
    private readonly ExampleHandler _handler;

    private readonly IServiceProvider _services;

    public IntegrationTests(TestInitialiser testIniter)
    {
        _services = testIniter.Host.Services;

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
}
