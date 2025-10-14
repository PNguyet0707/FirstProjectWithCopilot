using Worker;
using Microsoft.Extensions.DependencyInjection;
public class Program
{
   public static void Main(string[] args)
    {
       // var logProvider = new LogerProvider(logConfig);
        WorkerConfigurationManager.Init();
        var host = CreateHostBuilder(args);
        host.Build().Run();     
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) => {
                services.AddLogging( builder =>
                {
                    builder.ClearProviders();
                   // builder.AddProvider(logProvider)
                   builder.AddConsole();
                });
                //services.AddHttpClient();
                // add service .... 
                var serviceProvider = services.BuildServiceProvider();
            });
    }
}