using FluentAssertions;
using PuppeteerPdfLib;

namespace PuppeteerPdfLibTests
{
    public class HtmlPdfGeneratorTests
    {
        [Fact]
        public void Should_Generate_Pdf_File()
        {
            // arrange
            var filename = $"PuppeteerPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
            var generator = new HtmlPdfGenerator();

            // act
            generator.Generate("Hello World", filename);

            // assert
            File.Exists(filename).Should().BeTrue();
        }
    }
}