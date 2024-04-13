using System;
using Microsoft.Extensions.Configuration;
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
                services.AddTransient<AppRunner>();
            });

    private static void Configure(IHost host) 
    {
        // integrate appsettings.json configs, environment variables, etc.
        var configuration = host.Services.GetService<IConfiguration>();

        // configure the console
        Console.Title = "MightyMentorConsole.Template";
        // Console.BackgroundColor = ConsoleColor.Black;
        // Console.ForegroundColor = ConsoleColor.Gray;
        // Console.SetWindowSize(120, 30);
    }
}
