using System;
using MightyMentorConsole.Template.Utilities;

namespace MightyMentorConsole.Template;

internal class AppRunner
{
    // add config option to remove all comments

    internal void Run(string[] args)
    {
        // application entrypoint is here
        // Console.WriteLine("Hello, World!");
        // Console.ReadLine();

        while (true) 
        {
            Execute();
            ColorConsole.WriteSeparationLine();
        }
    }

    private static void Execute()
    {
        // application entrypoint is here
        Console.WriteLine("Hello, World!");
        Console.ReadLine();

        // with utils
        ColorConsole.WriteLine("Hello, World!");
        ColorConsole.ReadLine();
    }
}
