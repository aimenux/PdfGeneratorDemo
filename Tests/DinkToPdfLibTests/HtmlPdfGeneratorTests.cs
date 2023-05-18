using DinkToPdfLib;
using FluentAssertions;

namespace DinkToPdfLibTests
{
    public class HtmlPdfGeneratorTests
    {
        [Fact]
        public void Should_Generate_Pdf_File()
        {
            // arrange
            var filename = $"DinkToPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
            var generator = new HtmlPdfGenerator();

            // act
            generator.Generate("Hello World", filename);

            // assert
            File.Exists(filename).Should().BeTrue();
        }
    }
}