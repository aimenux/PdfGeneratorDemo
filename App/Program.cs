using App;
using AsposePdfLib;
using Contracts;
using DinkToPdfLib;
using IronPdfLib;
using ITextSharpPdfLib;
using Microsoft.Extensions.DependencyInjection;
using MigraDocCoreLib;
using PdfPigLib;
using PdfSharpLib;
using PugPdfLib;
using PuppeteerPdfLib;
using QuestPdfLib;
using SelectPdfLib;
using SpirePdfLib;
using WkHtmlToPdfLib;

var services = new ServiceCollection();
services
    .AddAsposePdfLib()
    .AddDinkToPdfLib()
    .AddIronPdfLib()
    .AddITextSharpPdfLib()
    .AddPdfSharpLib()
    .AddMigraDocCoreLib()
    .AddPdfPigLib()
    .AddPugPdfLib()
    .AddPuppeteerPdfLib()
    .AddQuestPdfLib()
    .AddSelectPdfLib()
    .AddSpirePdfLib()
    .AddWkHtmlToPdfLib();

var serviceProvider = services.BuildServiceProvider();
foreach (var pdfGenerator in serviceProvider.GetServices<IPdfGenerator>())
{
    var filename = pdfGenerator.BuildFileName();

    try
    {
        ConsoleColor.Green.WriteLine($"Generating {filename}");
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        await pdfGenerator.GenerateAsync("Hello World!", filename, cts.Token);
    }
    catch (Exception ex)
    {
        ConsoleColor.Red.WriteLine($"Failed to generate file {filename} : {ex.Message}");
    }
}

ConsoleColor.Yellow.WriteLine("Press any key to exit program !");
Console.ReadKey();