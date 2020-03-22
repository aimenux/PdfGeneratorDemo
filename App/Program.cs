using System;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection();
            services.AddTransient<IConsoleEnabler, ConsoleEnabler>();
            services.AddTransient<IPdfGenerator, PdfSharpLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, SelectPdfLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, SelectPdfLib.HtmlPdfGenerator>();
            services.AddTransient<IPdfGenerator, IronPdfLib.HtmlPdfGenerator>();

            var serviceProvider = services.BuildServiceProvider();
            var consoleEnabler = serviceProvider.GetService<IConsoleEnabler>();
            foreach (var pdfGenerator in serviceProvider.GetServices<IPdfGenerator>())
            {
                consoleEnabler.Off();
                var filename = $"{pdfGenerator.GetType().FullName}.pdf";
                pdfGenerator.Generate("Hello World!", filename);
                consoleEnabler.On();
            }

            Console.WriteLine("Press any key to exit program !");
            Console.ReadKey();
        }
    }
}
