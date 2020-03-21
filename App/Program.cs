using System;
using Contracts;
using Microsoft.Extensions.DependencyInjection;
using PdfSharpLib;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection();
            services.AddTransient<IPdfGenerator, PdfGenerator>();

            var serviceProvider = services.BuildServiceProvider();
            foreach (var pdfGenerator in serviceProvider.GetServices<IPdfGenerator>())
            {
                var filename = $"{pdfGenerator.GetType().Name}.pdf";
                pdfGenerator.Generate("Hello World!", filename);
            }

            Console.WriteLine("Press any key to exit program !");
            Console.ReadKey();
        }
    }
}
