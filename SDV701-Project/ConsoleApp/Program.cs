using ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestAPIClient;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = builder.Build();

var apiConfiguration = new APIConfiguration();
configuration.GetSection("APIConfiguration");

var serviceProvider = new ServiceCollection()
    .AddSingleton<IAPIConfiguration>(apiConfiguration)
    .AddSingleton<IConsoleApplication, ConsoleApplication>()
    .RegisterClients()
    .BuildServiceProvider();


IServiceScope scope = serviceProvider.CreateScope();
scope.ServiceProvider.GetRequiredService<IConsoleApplication>().Run();

if (serviceProvider is IDisposable)
{
    serviceProvider.Dispose();
}