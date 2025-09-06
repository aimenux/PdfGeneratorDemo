using Aspose.Pdf;
using Aspose.Pdf.Text;
using Contracts;

namespace AsposePdfLib;

public sealed class PdfGenerator : IPdfGenerator
{
    private const int FontSize = 50;
    private const int HeadingLevel = 1;
    private const float LineSpacing = 10f;
    private const FontStyles FontStyle = FontStyles.Bold;

    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        using var document = new Document();
        using var page = document.Pages.Add();
        var heading = new Heading(HeadingLevel)
        {
            Text = text,
            TextState =
            {
                FontSize = FontSize,
                FontStyle = FontStyle,
                LineSpacing = LineSpacing
            }
        };
        page.Paragraphs.Add(heading);
        document.Save(filename);
        return Task.CompletedTask;
    }
}