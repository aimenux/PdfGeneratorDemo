using App;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IPdfGenerator, PdfSharpLib.PdfGenerator>();
services.AddTransient<IPdfGenerator, SpirePdfLib.PdfGenerator>();
services.AddTransient<IPdfGenerator, AsposePdfLib.PdfGenerator>();
services.AddTransient<IPdfGenerator, SelectPdfLib.PdfGenerator>();
services.AddTransient<IPdfGenerator, PugPdfLib.HtmlPdfGenerator>();
services.AddTransient<IPdfGenerator, IronPdfLib.HtmlPdfGenerator>();
services.AddTransient<IPdfGenerator, DinkToPdfLib.HtmlPdfGenerator>();
services.AddTransient<IPdfGenerator, ITextSharpPdfLib.PdfGenerator>();
services.AddTransient<IPdfGenerator, SelectPdfLib.HtmlPdfGenerator>();
services.AddTransient<IPdfGenerator, PuppeteerPdfLib.HtmlPdfGenerator>();

var serviceProvider = services.BuildServiceProvider();
foreach (var pdfGenerator in serviceProvider.GetServices<IPdfGenerator>())
{
    var filename = BuildFileName(pdfGenerator);
    
    try
    {
        ConsoleColor.Green.WriteLine($"Generating {filename}");
        pdfGenerator.Generate("Hello World!", filename);
    }
    catch (Exception ex)
    {
        ConsoleColor.Red.WriteLine($"Failed to generate file {filename} : {ex.Message}");
    }
}

ConsoleColor.Yellow.WriteLine("Press any key to exit program !");
Console.ReadKey();

static string BuildFileName(IPdfGenerator pdfGenerator)
{
    const string extension = "pdf";
    var type = pdfGenerator.GetType();
    return $"{nameof(App)}.{type.FullName}.{extension}";
}