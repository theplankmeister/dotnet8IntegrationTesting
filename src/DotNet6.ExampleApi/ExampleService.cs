namespace DotNet6.ExampleApi;

public class ExampleService
{
    private readonly string _mySetting;

    public ExampleService(IConfiguration config)
    {
        _mySetting = config.GetValue<string>("MySetting")!;
    }

    public string GetMySetting() => _mySetting;
}
