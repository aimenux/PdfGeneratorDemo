using Contracts;
using PugPdf.Core;

namespace PugPdfLib;

public sealed class HtmlPdfGenerator : IPdfGenerator
{
    public async Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
        var converter = new HtmlToPdf { PrintOptions = { Title = nameof(PugPdfLib) } };
        var document = await converter.RenderHtmlAsPdfAsync(html);
        await document.SaveAsAsync(filename);
    }
}