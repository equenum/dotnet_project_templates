using System;
using System.ComponentModel;

namespace MightyMentorConsole.Template.Utilities;

internal static class ConsoleHelper
{
    public static T GetInput<T>(string prompt = null, string errorMessage = null)
    {
        ColorConsole.Write(prompt ?? $"Please enter your {typeof(T).Name} value: ");
        var input = ColorConsole.ReadLine().Trim();
        T result;

        while (string.IsNullOrWhiteSpace(input) || !TryParse<T>(input, out result))
        {
            ColorConsole.Write(errorMessage ?? "Invalid input! Please try again: ", ConsoleColor.Red);
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
            value = default(T);
            return false;
        }
    }
}
