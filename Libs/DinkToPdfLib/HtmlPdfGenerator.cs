using Contracts;
using DinkToPdf;

namespace DinkToPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        private const int FontSizeToUse = 12;
        private const string FontNameToUse = "Ariel";
        private const string EncodingToUse = "utf-8";
        private const ColorMode ColorModeToUse = ColorMode.Color;
        private const PaperKind PaperSizeToUse = PaperKind.A4Plus;
        private const Orientation OrientationToUse = Orientation.Landscape;
        
        public void Generate(string text, string filename)
        {
            var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
            var converter = new StaSynchronizedConverter(new PdfTools());
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = 
                {
                    Out = filename,
                    PaperSize = PaperSizeToUse,
                    ColorMode = ColorModeToUse,
                    Orientation = OrientationToUse
                },
                Objects = 
                {
                    new ObjectSettings 
                    {
                        PagesCount = true,
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = EncodingToUse },
                        HeaderSettings = { FontSize = FontSizeToUse, FontName = FontNameToUse }
                    }
                }
            };
            converter.Convert(document);
        }
    }
}
