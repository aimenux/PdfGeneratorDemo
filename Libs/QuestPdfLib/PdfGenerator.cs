using Contracts;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPdfLib
{
    public class PdfGenerator : IPdfGenerator
    {
        static PdfGenerator()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }
        
        public void Generate(string text, string filename)
        {
            void PageHandler(PageDescriptor page)
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                    .Text("QuestPdfLib")
                    .SemiBold()
                    .FontSize(50)
                    .FontFamily("Times New Roman")
                    .FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);
                        x.Item().Text(text);
                        x.Item().Image(Placeholders.Image(200, 100));
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            }

            Document
                .Create(container => container.Page(PageHandler))
                .GeneratePdf(filename);
        }
    }
}
