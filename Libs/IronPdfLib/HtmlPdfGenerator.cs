using Contracts;

namespace IronPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        public void Generate(string text, string filename)
        {
            var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
            using var converter = new HtmlToPdf();
            using var document = converter.RenderHtmlAsPdf(html);
            document.SaveAs(filename);
        }
    }
}
