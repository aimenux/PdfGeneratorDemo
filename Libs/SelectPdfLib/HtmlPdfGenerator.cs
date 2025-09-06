using Contracts;
using SelectPdf;

namespace SelectPdfLib;

public sealed class HtmlPdfGenerator : IPdfGenerator
{
    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
        var converter = new HtmlToPdf();
        var document = converter.ConvertHtmlString(html);
        document.Save(filename);
        document.Close();
        return Task.CompletedTask;
    }
}