using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MightyMentorConsole.Template;

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
            .ConfigureServices((context, services) => 
            {
                // configure DI services here
                services.AddTransient<AppRunner>();
            });

    private static void Configure(IHost host) 
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.console?view=net-8.0
        // use IHost to integrate appsettings.json configs
        Console.Title = "MightyConsole.Template";
        // Console.BackgroundColor = ConsoleColor.Blue;
        // Console.ForegroundColor = ConsoleColor.White;
    }
}
