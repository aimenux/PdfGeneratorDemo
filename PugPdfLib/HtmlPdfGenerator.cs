using Contracts;
using PugPdf.Core;

namespace PugPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        public void Generate(string text, string filename)
        {
            var html = $"<h1 style=\"font-size:100px;\">{text}</h1>";
            var converter = new HtmlToPdf {PrintOptions = {Title = nameof(PugPdfLib)}};
            var document = converter.RenderHtmlAsPdfAsync(html).GetAwaiter().GetResult();
            document.SaveAs(filename);
        }
    }
}
