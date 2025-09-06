using AwesomeAssertions;
using IronPdfLib;

namespace IronPdfLibTests;

public class HtmlPdfGeneratorTests
{
    [Fact]
    public async Task Should_Generate_Pdf_File()
    {
        // arrange
        var cancellationToken = CancellationToken.None;
        var filename = $"IronPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
        var generator = new HtmlPdfGenerator();

        // act
        await generator.GenerateAsync("Hello World", filename, cancellationToken);

        // assert
        File.Exists(filename).Should().BeTrue();
    }
}