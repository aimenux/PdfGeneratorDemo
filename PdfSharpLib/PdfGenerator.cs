using System;
using System.IO;
using Contracts;
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
            var font = GetFontAndDisableUnwantedLogs();
            var rectangle = new XRect(10, 10, page.Width, page.Height);
            graphics.DrawString(text, font, Brush, rectangle, Format);
            pdf.Save(filename);
        }

        private static XFont GetFontAndDisableUnwantedLogs()
        {
            ConsoleEnabler.Off();
            var font = new XFont(FamilyName, FontSize, FontStyle);
            ConsoleEnabler.On();
            return font;
        }

        private static class ConsoleEnabler
        {
            private static readonly TextWriter OutWriter = Console.Out;
            private static readonly TextWriter NullWriter = TextWriter.Null;

            public static void On() => Console.SetOut(OutWriter);
            public static void Off() => Console.SetOut(NullWriter);
        }
    }
}
