using Contracts;
using SelectPdf;

namespace SelectPdfLib;

public sealed class PdfGenerator : IPdfGenerator
{
    private const int FontSize = 100;
    private const PdfStandardFont FontName = PdfStandardFont.Helvetica;

    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        var document = new PdfDocument();
        var page = document.AddPage();
        var font = document.AddFont(FontName);
        font.Size = FontSize;
        var element = new PdfTextElement(50, 50, text, font);
        page.Add(element);
        document.Save(filename);
        document.Close();
        return Task.CompletedTask;
    }
}