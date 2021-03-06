﻿using Contracts;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace PdfSharpLib
{
    public class PdfGenerator : IPdfGenerator
    {
        private const int FontSize = 100;
        private const string FamilyName = "OpenSans";
        private const XFontStyle FontStyle = XFontStyle.Bold;
        private static readonly XSolidBrush Brush = XBrushes.Black;
        private static readonly XStringFormat Format = XStringFormats.TopLeft;

        public void Generate(string text, string filename)
        {
            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            var font = new XFont(FamilyName, FontSize, FontStyle);
            var rectangle = new XRect(10, 10, page.Width, page.Height);
            graphics.DrawString(text, font, Brush, rectangle, Format);
            pdf.Save(filename);
        }
    }
}
