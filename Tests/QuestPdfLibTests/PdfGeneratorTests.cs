using FluentAssertions;
using QuestPdfLib;

namespace QuestPdfLibTests
{
    public class PdfGeneratorTests
    {
        [Fact]
        public void Should_Generate_Pdf_File()
        {
            // arrange
            var filename = $"QuestPdfLibTests-{DateTime.Now:yyMMddHHmmss}.pdf";
            var generator = new PdfGenerator();

            // act
            generator.Generate("Hello World", filename);

            // assert
            File.Exists(filename).Should().BeTrue();
        }
    }
}