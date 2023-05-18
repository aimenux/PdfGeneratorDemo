using System.Drawing;
using Contracts;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace SpirePdfLib
{
    public class PdfGenerator : IPdfGenerator
    {
        private const float Size = 50f;
        private const PdfFontStyle Style = PdfFontStyle.Bold;
        private static readonly PdfPen Pen = PdfPens.DarkGoldenrod;
        private const PdfFontFamily FontFamily = PdfFontFamily.TimesRoman;
        private static readonly PdfStringFormat Format = new PdfStringFormat();
        private static readonly PdfSolidBrush Brush = new PdfSolidBrush(Color.White);
        private static readonly PdfFont Font = new PdfFont(FontFamily, Size, Style);

        public void Generate(string text, string filename)
        {
            using var document = new PdfDocument();
            document.Pages.Add();
            var page = document.Pages[0];
            var state = page.Canvas.Save();
            var rectangle = new RectangleF(10, 10, 200, 200);
            page.Canvas.DrawString(text, Font, Pen, Brush, rectangle, Format);
            page.Canvas.Restore(state);
            document.SaveToFile(filename);
        }
    }
}
