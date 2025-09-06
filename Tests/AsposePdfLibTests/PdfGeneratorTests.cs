using AsposePdfLib;
using AwesomeAssertions;

namespace AsposePdfLibTests;

public class PdfGeneratorTests
{
    [Fact]
    public async Task Should_Generate_Pdf_File()
    {
        // arrange
        var cancellationToken = CancellationToken.None;
        var filename = $"AsposePdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
        var generator = new PdfGenerator();

        // act
        await generator.GenerateAsync("Hello World", filename, cancellationToken);

        // assert
        File.Exists(filename).Should().BeTrue();
    }
}