﻿using Contracts;
using PuppeteerSharp;

namespace PuppeteerPdfLib
{
    public class HtmlPdfGenerator : IPdfGenerator
    {
        // static HtmlPdfGenerator()
        // {
        //     new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision).GetAwaiter().GetResult();
        // }

        public void Generate(string text, string filename)
        {
            var options = new LaunchOptions { Headless = true };
            using var browser = Puppeteer.LaunchAsync(options).GetAwaiter().GetResult();
            using var page = browser.NewPageAsync().GetAwaiter().GetResult();
            page.SetContentAsync(text).GetAwaiter().GetResult();
            page.PdfAsync(filename).GetAwaiter().GetResult();
        }
    }
}