namespace MultipurposeUi.Data
{
    public interface ITextFileReader
    {
        //IAsyncEnumerable<string> ReadTextFile(string filepath);
    }

    public class TextFileReader : ITextFileReader
    {
        public static async IAsyncEnumerable<string> ReadTextFile(string filepath)
        {
            using StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                Thread.Sleep(1000);
                yield return await reader.ReadLineAsync();
            }
        }
    }
}
