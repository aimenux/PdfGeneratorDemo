using FluentAssertions;
using IronPdfLib;

namespace IronPdfLibTests
{
    public class HtmlPdfGeneratorTests
    {
        [Fact]
        public void Should_Generate_Pdf_File()
        {
            // arrange
            var filename = $"IronPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
            var generator = new HtmlPdfGenerator();

            // act
            generator.Generate("Hello World", filename);

            // assert
            File.Exists(filename).Should().BeTrue();
        }
    }
}