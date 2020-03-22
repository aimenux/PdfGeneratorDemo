using Contracts;
using IronPdf;

namespace IronPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        public void Generate(string text, string filename)
        {
            var html = $"<h1 style=\"font-size:100px;\">{text}</h1>";
            var converter = new HtmlToPdf();
            var document = converter.RenderHtmlAsPdf(html);
            document.SaveAs(filename);
        }
    }
}
