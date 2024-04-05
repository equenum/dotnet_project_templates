#if IncludeUtils
using MightyMentorConsole.Template.Utilities;
#else
using System;
#endif

namespace MightyMentorConsole.Template;

internal class AppRunner
{
    internal void Run(string[] args)
    {
        // application entrypoint is here
        #if IncludeUtils
        ColorConsole.WriteLine("Hello, World!");
        #else
        Console.WriteLine("Hello, World!");
        #endif
    }
}
