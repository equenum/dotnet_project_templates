using System;
using Microsoft.Extensions.Hosting;

namespace MightyConsole.Template;

internal class Program
{
    static void Main(string[] args)
    {
        // todo set custom console name
        Console.Title = "MightyConsole.Template";

        // todo create and run the builder
        var builder = CreateHostBuilder(args);
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) => 
            {
                // Configure DoC services here
            });
}


