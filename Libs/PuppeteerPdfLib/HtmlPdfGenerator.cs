using Contracts;
using PuppeteerSharp;

namespace PuppeteerPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        static HtmlPdfGenerator()
        {
            DownloadProcessRevisionAsync().GetAwaiter().GetResult();
        }

        public void Generate(string text, string filename)
        {
            var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
            var options = new LaunchOptions { Headless = true };
            using var browser = Puppeteer.LaunchAsync(options).GetAwaiter().GetResult();
            using var page = browser.NewPageAsync().GetAwaiter().GetResult();
            page.SetContentAsync(html).GetAwaiter().GetResult();
            page.PdfAsync(filename).GetAwaiter().GetResult();
        }

        private static async Task DownloadProcessRevisionAsync()
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
        }
    }
}
