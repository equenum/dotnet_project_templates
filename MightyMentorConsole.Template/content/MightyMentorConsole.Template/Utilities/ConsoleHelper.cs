using System;
using System.ComponentModel;

namespace MightyMentorConsole.Template.Utilities;

internal static class ConsoleHelper
{
    /// <summary>
    /// Reads user input form the console. 
    ///     If invalid, prompts to repeat; 
    ///     if valid, converts to the specified type.
    /// </summary>
    /// <typeparam name="T">The expected input value type.</typeparam>
    /// <param name="prompt">The prompt message written to the console.</param>
    /// <param name="errorMessage">The error message written to the console.</param>
    /// <returns>The console input value converted to the specified type.</returns>
    public static T GetInput<T>(string prompt = null, string errorMessage = null)
    {
        ColorConsole.Write(prompt ?? $"Please enter your {typeof(T).Name} value: ");
        var input = ColorConsole.ReadLine().Trim();
        T result;

        while (string.IsNullOrWhiteSpace(input) || !TryParse<T>(input, out result))
        {
            ColorConsole.Write(errorMessage ?? "Invalid input! Please try again: ",
                ConsoleColor.Red);

            input = ColorConsole.ReadLine().Trim();
        }
        
        return result;
    }

    private static bool TryParse<T>(string input, out T value) 
    {
        var converter = TypeDescriptor.GetConverter(typeof(T));

        try 
        {
            value = (T) converter.ConvertFromString(input);
            return true;
        } 
        catch 
        {
            value = default;
            return false;
        }
    }
}
