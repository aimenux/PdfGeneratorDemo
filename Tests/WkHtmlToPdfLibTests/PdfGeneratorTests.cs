using AwesomeAssertions;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfLib;

namespace WkHtmlToPdfLibTests;

public class PdfGeneratorTests
{
    [Fact]
    public async Task Should_Generate_Pdf_File()
    {
        // arrange
        var cancellationToken = CancellationToken.None;
        var filename = $"WkHtmlToPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
        var convertor = new StaSynchronizedConverter(new PdfTools());
        var generator = new HtmlPdfGenerator(convertor);

        // act
        await generator.GenerateAsync("Hello World", filename, cancellationToken);

        // assert
        File.Exists(filename).Should().BeTrue();
    }
}