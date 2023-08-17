using NUnit.Framework;
using ReadWithMinimalResource;

namespace ReadWithMinimalResourceTests
{
    [TestFixture]
    public class TextFileGeneratorTests
    {
        [Test]
        public async Task GenerateFileTests()
        {
            var textFileGenerator = new TextFileGenerator();
            var result = await textFileGenerator.GenerateFileAsync("TestFile.txt");

            Assert.IsTrue(result);

        }
    }
}