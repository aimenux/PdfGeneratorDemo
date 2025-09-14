using Contracts;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Writer;

namespace PdfPigLib;

public sealed class PdfGenerator : IPdfGenerator
{
    public async Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        using var builder = new PdfDocumentBuilder();
        var page = builder.AddPage(PageSize.A4);
        var font = builder.AddStandard14Font(Standard14Font.Helvetica);
        page.AddText(text, fontSize: 12, position: new PdfPoint(25, 700), font);
        var bytes = builder.Build();
        await File.WriteAllBytesAsync(filename, bytes, cancellationToken);
    }
}