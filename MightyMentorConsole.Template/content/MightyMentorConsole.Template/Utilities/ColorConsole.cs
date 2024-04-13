using System;

namespace MightyMentorConsole.Template.Utilities;

internal static class ColorConsole
{
    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the console applying the foreground color, if specified.
    /// </summary>
    /// <param name="text">The value to write.</param>
    /// <param name="color">The color the value is written in.</param>
    public static void WriteLine(string text, ConsoleColor? color = null) =>
        WriteInternal(text, Console.WriteLine, color);

    /// <summary>
    /// Writes the specified string value to the console applying the foreground color, if specified.
    /// </summary>
    /// <param name="text">The value to write.</param>
    /// <param name="color">The color the value is written in.</param>
    public static void Write(string text, ConsoleColor? color = null) =>
        WriteInternal(text, Console.Write, color);

    /// <summary>
    /// Writes a separation line to the console, including a header, if specified.
    /// </summary>
    /// <param name="header">The header value (defaults to an empty string).</param>
    /// <param name="paddingSize">The padding size (applied to both sides of the header value, defaults to 5).</param>
    /// <param name="paddingChar">The character the padding is composed of (defaults to '*')</param>
    /// <param name="color">The color the separation line is written in (defaults to gray).</param>
    public static void WriteSeparationLine(string header = "", int paddingSize = 5,
        char paddingChar = '*', ConsoleColor color = ConsoleColor.Gray) 
    {
        var padding = new string(paddingChar, paddingSize);
        WriteLine($"\n{padding}{header}{padding}\n", color);
    }

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the console in green color.
    /// </summary>
    /// <param name="text">The value to write.</param>
    public static void WriteSuccess(string text) => 
        WriteLine(text, ConsoleColor.Green);

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the console in red color.
    /// </summary>
    /// <param name="text">The value to write.</param>
    public static void WriteError(string text) =>
        WriteLine(text, ConsoleColor.Red);

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the console in white color.
    /// </summary>
    /// <param name="text">The value to write.</param>
    public static void WriteInfo(string text) =>
        WriteLine(text, ConsoleColor.White);

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the console in dark yellow color.
    /// </summary>
    /// <param name="text">The value to write.</param>
    public static void WriteWarning(string text) => 
        WriteLine(text, ConsoleColor.DarkYellow);

    /// <summary>
    /// Writes the current line terminator to the console.
    /// </summary>
    public static void WriteLine() => Console.WriteLine();

    /// <summary>
    /// Obtains the next character or function key pressed by the user from the console.
    /// </summary>
    public static void ReadKey() => Console.ReadKey();

    /// <summary>
    /// Reads the next line of characters from the console.
    /// </summary>
    /// <returns>The console input.</returns>
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
