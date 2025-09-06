using Contracts;
using PuppeteerSharp;

namespace PuppeteerPdfLib;

public sealed class HtmlPdfGenerator : IPdfGenerator
{
    static HtmlPdfGenerator()
    {
        DownloadProcessRevisionAsync().GetAwaiter().GetResult();
    }
    
    public async Task GenerateAsync(string text, string filename, CancellationToken cancellationToken)
    {
        var html = $"<h1 style=\"font-size:100px;color:blue;\">{text}</h1>";
        var options = new LaunchOptions { Headless = true };
        await using var browser = await Puppeteer.LaunchAsync(options);
        await using var page = await browser.NewPageAsync();
        await page.SetContentAsync(html);
        await page.PdfAsync(filename);
    }

    private static async Task DownloadProcessRevisionAsync()
    {
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();
    }
}