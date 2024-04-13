## MightyMentorConsole.Template

A simple .Net Console App template tailored for better workshops, live coding sessions, and knowledge-sharing experiences. Can be useful to mentors/trainers for showcasing not only basic C# syntax and features but also more advanced concepts, like Dependency Injection, application settings, asynchronous and parallel execution, and so on. Offers a set of useful built-in utilities, making working with the console easier and more visually precise. The utilities and project structure are kept simple so that they are easy to understand for beginner developers.

### Utilities

#### [ColorConsole](MightyMentorConsole.Template/Utilities/ColorConsole.cs)

Offers a set of methods that allow for writing to console in color for better visibility (wraps around System.Console and implements all the most often used methods).

```csharp
ColorConsole.WriteLine(); // line terminator

ColorConsole.WriteSuccess("Success !"); // writes in green
ColorConsole.WriteError("Error =("); // writes in red
ColorConsole.WriteWarning("Warning !"); // writes in dark yellow

ColorConsole.WriteLine(
    text: "Write text in a specific color",
    color: ConsoleColor.DarkYellow);

// writes '*****Header*****'
ColorConsole.WriteSeparationLine(
    header: "Header",
    paddingSize: 5,
    paddingChar: '*',
    color: ConsoleColor.DarkGreen);
```

#### [ConsoleHelper](MightyMentorConsole.Template/Utilities/ConsoleHelper.cs)

Offers a set of methods that allow for simpler and cleaner console input parsing.

```csharp
// reads user input form the console.
// if invalid, prompts to repeat; else, converts to the specified type.
var number = ConsoleHelper.GetInput<int>(
    prompt: $"Please enter your number: ",
    errorMessage: "Invalid input! Please try again: ");
```

### Parameters

- **IncludeAppsettings:** Includes `appsettings.json` and `appsettings.Development.json` (defaults to `true`).
- **IncludeSln:** Includes a solution file (defaults to `false`).
- **IncludeUtils:** Includes template specific utility classes (defaults to `true`).

### Configurations

Dependency Injection:

```csharp
private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            // configure DI services here
            services.AddTransient<AppRunner>();
        });
```

Console configurations and access to `appsettings.json` via `IConfiguration`:

```csharp
private static void Configure(IHost host)
{
    // integrate appsettings.json configs, environment variables, etc.
    var configuration = host.Services.GetService<IConfiguration>();

    // configure the console
    Console.Title = "MightyConsole.Template";
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetWindowSize(120, 30);
}
```

### Install

The template is available in the Nuget.org package source.

Install via .Net CLI:

```shell
dotnet new --install MightyMentorConsole.Template
```

Install via Visual Studio 2022 GUI: `Placeholder`

### Uninstall

```shell
dotnet new --uninstall MightyMentorConsole.Template
```

Uninstall via Visual Studio 2022 GUI: `Placeholder`

### Notes

- The template was written and tested for `Visual Studio 2022` and `.Net8`. It might not work or require adjustments for other configurations.
- Please open an issue in case of feature suggestions, errors found, or any other form of feedback! Thanks!
