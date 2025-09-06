using FluentAssertions;
using PuppeteerPdfLib;

namespace PuppeteerPdfLibTests;

public class HtmlPdfGeneratorTests
{
    [Fact]
    public async Task Should_Generate_Pdf_File()
    {
        // arrange
        var cancellationToken = CancellationToken.None;
        var filename = $"PuppeteerPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
        var generator = new HtmlPdfGenerator();

        // act
        await generator.GenerateAsync("Hello World", filename, cancellationToken);

        // assert
        File.Exists(filename).Should().BeTrue();
    }
}