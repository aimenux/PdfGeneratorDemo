using AwesomeAssertions;
using PdfSharpLib;

namespace PdfSharpLibTests;

public class PdfGeneratorTests
{
    [Fact]
    public async Task Should_Generate_Pdf_File()
    {
        // arrange
        var cancellationToken = CancellationToken.None;
        var filename = $"PdfSharpLibTests-{DateTime.Now:yyMMddHHmmssfff}.pdf";
        var generator = new PdfGenerator();

        // act
        await generator.GenerateAsync("Hello World", filename, cancellationToken);

        // assert
        File.Exists(filename).Should().BeTrue();
    }
}