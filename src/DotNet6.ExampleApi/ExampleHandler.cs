namespace DotNet6.ExampleApi;

public class ExampleHandler
{
    private readonly ExampleService _exampleService;

    public ExampleHandler(ExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    [FunctionName(nameof(ExampleEndpoint))]
    public IActionResult ExampleEndpoint([HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get))] HttpRequest req)
    {
        return new OkObjectResult($"This is the value of the config setting 'MySetting': {_exampleService.GetMySetting()}");
    }
}
