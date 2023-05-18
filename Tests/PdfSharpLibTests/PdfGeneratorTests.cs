using FluentAssertions;
using PdfSharpLib;

namespace PdfSharpLibTests
{
    public class PdfGeneratorTests
    {
        [Fact]
        public void Should_Generate_Pdf_File()
        {
            // arrange
            var filename = $"PdfSharpLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
            var generator = new PdfGenerator();

            // act
            generator.Generate("Hello World", filename);

            // assert
            File.Exists(filename).Should().BeTrue();
        }
    }
}