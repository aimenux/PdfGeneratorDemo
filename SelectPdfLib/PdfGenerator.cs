using Contracts;
using SelectPdf;

namespace SelectPdfLib
{
    public class PdfGenerator : IPdfGenerator
    {
        private const int FontSize = 100;
        private const PdfStandardFont FontName = PdfStandardFont.Helvetica;

        public void Generate(string text, string filename)
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var font = document.AddFont(FontName);
            font.Size = FontSize;
            var element = new PdfTextElement(50, 50, text, font);
            page.Add(element);
            document.Save(filename);
            document.Close();
        }
    }
}
