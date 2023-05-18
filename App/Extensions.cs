namespace App
{
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
}
