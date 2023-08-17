namespace ReadWithMinimalResource
{
    public interface ITextFileReader
    {
        IAsyncEnumerable<string> ReadTextFile(string filepath);
    }

    public class TextFileReader : ITextFileReader
    {
        public async IAsyncEnumerable<string> ReadTextFile(string filepath)
        {
            using StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
                yield return await reader.ReadLineAsync();
        }
    }
}
