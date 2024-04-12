using System;

namespace MightyMentorConsole.Template.Utilities;

internal static class ColorConsole
{
    public static void WriteLine(string text, ConsoleColor? color = null) =>
        WriteInternal(text, Console.WriteLine, color);

    public static void Write(string text, ConsoleColor? color = null) =>
        WriteInternal(text, Console.Write, color);

    public static void WriteSeparationLine(int length = 5, string header = "",
        char separatorChar = '*', ConsoleColor color = ConsoleColor.Gray) 
    {
        var separator = new string(separatorChar, length);
        WriteLine($"\n{separator}{header}{separator}\n", color);
    }

    public static void WriteSuccess(string text) => 
        WriteLine(text, ConsoleColor.Green);

    public static void WriteError(string text) =>
        WriteLine(text, ConsoleColor.Red);
    
    public static void WriteInfo(string text) =>
        WriteLine(text, ConsoleColor.Gray);
   
    public static void WriteWarning(string text) => 
        WriteLine(text, ConsoleColor.DarkYellow);

    public static void WriteLine() => Console.WriteLine();

    public static void ReadKey() => Console.ReadKey();

    public static string ReadLine() => Console.ReadLine();

    private static void WriteInternal(string text, Action<string> writeAction,
        ConsoleColor? color = null)
    {
        if (color.HasValue)
        {
            var currentColor = Console.ForegroundColor;

            if (color == currentColor)
            {
                writeAction(text);
                return;
            }
                
            Console.ForegroundColor = color.Value;
            writeAction(text);
            Console.ForegroundColor = currentColor;

            return;
        }
        
        writeAction(text);
    }
}
