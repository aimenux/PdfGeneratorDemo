using Contracts;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ITextSharpPdfLib
{
    public class PdfGenerator : IPdfGenerator
    {
        public void Generate(string text, string filename)
        {
            var writer = new PdfWriter(filename);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            document.Add(new Paragraph(text));
            document.Close();
        }
    }
}
