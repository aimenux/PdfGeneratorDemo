using Contracts;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.Rendering;

namespace MigraDocCoreLib;

public sealed class PdfGenerator : IPdfGenerator
{
    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        var document = new Document();
        document
            .AddSection()
            .AddParagraph(text);
        var renderer = new PdfDocumentRenderer
        {
            Document = document
        };
        renderer.RenderDocument();
        renderer.PdfDocument.Save(filename);
        return Task.CompletedTask;
    }
}