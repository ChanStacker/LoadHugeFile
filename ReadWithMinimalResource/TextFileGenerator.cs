using static System.Net.Mime.MediaTypeNames;

namespace ReadWithMinimalResource
{
    public interface ITextFileGenerator
    {
        Task<bool> GenerateFileAsync(string filePath);
    }

    public class TextFileGenerator : ITextFileGenerator
    {
        private long maxSizeInBytes = 2_147_483_648; 
        //private long maxSizeInBytes = 48; 
        public async Task<bool> GenerateFileAsync(string filePath)
        {
            int counter = 0;

            var writeTask = new Task(() =>
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    long currentSize = 0;
                    while (currentSize < maxSizeInBytes)
                    {
                        counter++;
                        writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}-counter{counter}");
                        currentSize = new FileInfo(filePath).Length;
                    }
                }
            });
            writeTask.Start();
            await Task.WhenAll(writeTask);

            return true;
        }

        public static void WriteTextToFile(string filePath, string text, long maxSizeInBytes)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                long currentSize = 0;
                while (currentSize < maxSizeInBytes)
                {
                    writer.Write(text);
                    currentSize = new FileInfo(filePath).Length;
                }
            }
        }
    }
}
