namespace DotNet8.ExampleApi;

public class ExampleService(IConfiguration config)
{
    private readonly string _mySetting = config.GetValue<string>("MySetting")!;

    public string GetMySetting() => _mySetting;
}
