using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MightyConsole.Template;

internal class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        Configure(host); 

        var appRunner = ActivatorUtilities.CreateInstance<AppRunner>(host.Services);
        appRunner.Run(args);
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
            .UseConsoleLifetime()
            .ConfigureServices((context, services) => 
            {
                // configure DI services here
                services.AddTransient<AppRunner>();
            });

    private static void Configure(IHost host) 
    {
        // use IHost to retrieve appsettings.json configs
        Console.Title = "MightyConsole.Template";
    }
}
