using System;
using System.IO;
using Contracts;

namespace App
{
    public class ConsoleEnabler : IConsoleEnabler
    {
        private static readonly TextWriter OutWriter = Console.Out;
        private static readonly TextWriter NullWriter = TextWriter.Null;

        public void On()
        {
            Console.SetOut(OutWriter);
            Console.SetError(OutWriter);
        }

        public void Off()
        {
            Console.SetOut(NullWriter);
            Console.SetError(NullWriter);
        }
    }
}
