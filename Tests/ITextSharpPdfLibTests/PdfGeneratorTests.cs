using FluentAssertions;
using ITextSharpPdfLib;

namespace ITextSharpPdfLibTests
{
    public class PdfGeneratorTests
    {
        [Fact]
        public void Should_Generate_Pdf_File()
        {
            // arrange
            var filename = $"ITextSharpPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
            var generator = new PdfGenerator();

            // act
            generator.Generate("Hello World", filename);

            // assert
            File.Exists(filename).Should().BeTrue();
        }
    }
}