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
            services.AddTransient<IPdfGenerator, SpirePdfLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, AsposePdfLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, IronPdfLib.HtmlPdfGenerator>();
            services.AddTransient<IPdfGenerator, SelectPdfLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, SelectPdfLib.HtmlPdfGenerator>();

            var serviceProvider = services.BuildServiceProvider();
            var consoleEnabler = serviceProvider.GetService<IConsoleEnabler>();
            foreach (var pdfGenerator in serviceProvider.GetServices<IPdfGenerator>())
            {
                consoleEnabler.Off();
                var filename = BuildFileName(pdfGenerator);
                pdfGenerator.Generate("Hello World!", filename);
                consoleEnabler.On();
            }

            Console.WriteLine("Press any key to exit program !");
            Console.ReadKey();
        }

        private static string BuildFileName(IPdfGenerator pdfGenerator)
        {
            const string extension = "pdf";
            var type = pdfGenerator.GetType();
            return $"{nameof(App)}.{type.FullName}.{extension}";
        }
    }
}
