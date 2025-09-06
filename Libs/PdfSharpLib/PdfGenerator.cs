using Contracts;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace PdfSharpLib;

public sealed class PdfGenerator : IPdfGenerator
{
    private const int FontSize = 100;
    private const string FamilyName = "OpenSans";
    private const XFontStyle FontStyle = XFontStyle.Bold;
    private static readonly XSolidBrush Brush = XBrushes.Black;
    private static readonly XStringFormat Format = XStringFormats.TopLeft;

    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        using var pdf = new PdfDocument();
        var page = pdf.AddPage();
        using var graphics = XGraphics.FromPdfPage(page);
        var font = new XFont(FamilyName, FontSize, FontStyle);
        var rectangle = new XRect(10, 10, page.Width, page.Height);
        graphics.DrawString(text, font, Brush, rectangle, Format);
        pdf.Save(filename);
        return Task.CompletedTask;
    }
}