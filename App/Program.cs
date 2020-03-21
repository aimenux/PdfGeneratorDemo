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
            services.AddTransient<IPdfGenerator, PdfSharpLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, SelectPdfLib.PdfGenerator>();
            services.AddTransient<IPdfGenerator, SelectPdfLib.HtmlPdfGenerator>();

            var serviceProvider = services.BuildServiceProvider();
            foreach (var pdfGenerator in serviceProvider.GetServices<IPdfGenerator>())
            {
                var filename = $"{pdfGenerator.GetType().FullName}.pdf";
                pdfGenerator.Generate("Hello World!", filename);
            }

            Console.WriteLine("Press any key to exit program !");
            Console.ReadKey();
        }
    }
}
