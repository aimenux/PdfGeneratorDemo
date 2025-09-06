using Contracts;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPdfLib;

public sealed class PdfGenerator : IPdfGenerator
{
    static PdfGenerator()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }
    
    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        Document
            .Create(container => container.Page(page => PageHandler(page, text)))
            .GeneratePdf(filename);
        
        return Task.CompletedTask;
    }

    private static void PageHandler(PageDescriptor page, string text)
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(20));

        page.Header()
            .Text("QuestPdfLib")
            .SemiBold()
            .FontSize(50)
            .FontFamily("Times New Roman")
            .FontColor(Colors.Blue.Medium);

        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Spacing(20);
                x.Item().Text(text);
                x.Item().Image(Placeholders.Image(200, 100));
            });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
    }
}