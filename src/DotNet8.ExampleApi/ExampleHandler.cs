namespace DotNet8.ExampleApi;

public class ExampleHandler(ExampleService exampleService)
{
    [Function(nameof(ExampleEndpoint))]
    public IActionResult ExampleEndpoint([HttpTrigger(AuthorizationLevel.Function, nameof(HttpMethods.Get))] HttpRequest req)
    {
        return new OkObjectResult($"This is the value of the config setting 'MySetting': {exampleService.GetMySetting()}");
    }
}
