using Contracts;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using HtmlRendererCore = TheArtOfDev.HtmlRenderer.PdfSharp;

namespace PdfSharpLib;

public sealed class HtmlPdfGenerator : IPdfGenerator
{
    public Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        using var pdf = new PdfDocument();
        var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
        HtmlRendererCore.PdfGenerator.AddPdfPages(pdf, html, PageSize.A4);
        pdf.Save(filename);
        return Task.CompletedTask;
    }
}