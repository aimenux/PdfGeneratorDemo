using Contracts;

namespace App;

public static class Extensions
{
    private static readonly TextWriter OutWriter = Console.Out;
    private static readonly TextWriter NullWriter = TextWriter.Null;

    public static void WriteLine(this ConsoleColor color, object value)
    {
        EnableConsole();
        Console.ForegroundColor = color;
        Console.WriteLine(value);
        Console.ResetColor();
        DisableConsole();
    }

    public static string BuildFileName(this IPdfGenerator pdfGenerator)
    {
        const string extension = "pdf";
        var name = pdfGenerator.GetType().FullName?.Replace(".", "-");
        return $"{DateTime.Now:yyyyMMddHHmmss}-{name}.{extension}";
    }

    private static void EnableConsole()
    {
        Console.SetOut(OutWriter);
        Console.SetError(OutWriter);
    }

    private static void DisableConsole()
    {
        Console.SetOut(NullWriter);
        Console.SetError(NullWriter);
    }
}