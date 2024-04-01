using System;

namespace MightyMentorConsole.Template.Utilities;

internal static class ColorConsole
{
    // validate inputs everywhere?

    // refactor to pass action
    public static void WriteLine(string text, ConsoleColor? color = null)
    {
        if (color.HasValue)
        {
            var previousColor = Console.ForegroundColor;

            if (color == previousColor)
            {
                Console.WriteLine(text);
                return;
            }
                
            Console.ForegroundColor = color.Value;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;

            return;
        }
        
        Console.WriteLine(text);
    }

    // refactor to pass action
    public static void Write(string text, ConsoleColor? color = null)
    {
        if (color.HasValue)
        {
            var previousColor = Console.ForegroundColor;

            if (color == previousColor)
            {
                Console.Write(text);
                return;
            }
                
            Console.ForegroundColor = color.Value;
            Console.Write(text);
            Console.ForegroundColor = previousColor;

            return;
        }
        
        Console.Write(text);
    }

    public static void WriteHeader(string headerText, char separatorChar = '*',
        ConsoleColor color = ConsoleColor.Gray) 
    {
        var separationLine = new string(separatorChar, headerText.Length);

        WriteLine(separationLine, color);
        WriteLine(separationLine, color);
        WriteLine(separationLine, color);
    }

     public static void WriteSeparationLine(int length = 10, char separatorChar = '*',
        ConsoleColor color = ConsoleColor.Gray) 
    {
        var separationLine = new string(separatorChar, length);

        WriteLine("\n" + separationLine + "\n", color);
    }

    public static void WriteLine() =>
        Console.WriteLine();

    public static void ReadKey() =>
        Console.ReadKey();

    public static string ReadLine() =>
        Console.ReadLine();

    public static void WriteSuccess(string text) =>
        WriteLine(text, ConsoleColor.Green);

    public static void WriteError(string text) =>
        WriteLine(text, ConsoleColor.Red);
    
    public static void WriteInfo(string text) =>
        WriteLine(text, ConsoleColor.Gray);
   
    public static void WriteWarning(string text) => 
        WriteLine(text, ConsoleColor.DarkYellow);
}
