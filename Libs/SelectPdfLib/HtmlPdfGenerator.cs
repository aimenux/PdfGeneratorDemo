using Contracts;
using SelectPdf;

namespace SelectPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        public void Generate(string text, string filename)
        {
            var html = $"<h1 style=\"font-size:100px;\">{text}</h1>";
            var converter = new HtmlToPdf();
            var document = converter.ConvertHtmlString(html);
            document.Save(filename);
            document.Close();
        }
    }
}