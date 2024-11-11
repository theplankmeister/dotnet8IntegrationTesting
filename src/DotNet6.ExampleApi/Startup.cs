[assembly: FunctionsStartup(typeof(Startup))]
namespace DotNet6.ExampleApi;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddTransient<ExampleService>();
    }
}