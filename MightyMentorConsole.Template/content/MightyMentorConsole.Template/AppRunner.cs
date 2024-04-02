using MightyMentorConsole.Template.Utilities;

namespace MightyMentorConsole.Template;

internal class AppRunner
{
    internal void Run(string[] args)
    {
        // application entrypoint is here
        // ColorConsole.WriteLine("Hello, World!");

        while (true) 
        {
            Execute();
            ColorConsole.WriteSeparationLine();
        }
    }

    private static void Execute()
    {
        // application entrypoint is here
        // ColorConsole.WriteLine("Hello, World!");
    }
}
