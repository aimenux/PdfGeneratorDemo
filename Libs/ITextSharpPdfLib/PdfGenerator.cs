using Contracts;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ITextSharpPdfLib;

public sealed class PdfGenerator : IPdfGenerator
{
    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        using var writer = new PdfWriter(filename);
        using var pdf = new PdfDocument(writer);
        using var document = new Document(pdf);
        document.Add(new Paragraph(text));
        document.Close();
        return Task.CompletedTask;
    }
}