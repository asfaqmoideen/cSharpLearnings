using System.Collections.Generic;
using FilesStreamsReadWrite;

namespace Assignments
{
    /// <summary>
    /// Initiates the program execution
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        private static async Task Main()
        {
            Console.WriteLine("File Stream Manager");
            try
            {
                ExecuteSyncStreams();

                await ExecuteAsyncStreams();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void ExecuteSyncStreams()
        {
            SynchronousStreamProccessor syncStream = new ();
            Dictionary<string, string> syncFilePaths = new Dictionary<string, string>()
                {
                    { @"C:\FileStreams\newlyWrittenFile.txt", @"C:\FileStreams\processedData.txt" },
                    { @"C:\FileStreams\newlyWrittenFile1.txt", @"C:\FileStreams\processedData1.txt" },
                    { @"C:\FileStreams\newlyWrittenFile2.txt", @"C:\FileStreams\processedData2.txt" },
                };

            foreach (KeyValuePair<string, string> pair in syncFilePaths)
            {
                syncStream.FileStreamWriter(pair.Key);
                syncStream.FileStreamReader(pair.Key);
                syncStream.BufferedStreamReader(pair.Key);
                syncStream.ReadProccesAndWriteDataToNewFile(pair.Key, pair.Value);
            }
        }

        private static async Task ExecuteAsyncStreams()
        {
            AsynchronousStreamProcessor asyncStream = new ();
            Dictionary<string, string> asyncFilePaths = new Dictionary<string, string>()
                {
                    { @"C:\FileStreams\asyncnewlyWrittenFile.txt", @"C:\FileStreams\asyncprocessesData.txt" },
                    { @"C:\FileStreams\asyncnewlyWrittenFile1.txt", @"C:\FileStreams\asyncprocessesData1.txt" },
                    { @"C:\FileStreams\asyncnewlyWrittenFile2.txt", @"C:\FileStreams\asyncprocessesData2.txt" },
                };

            foreach (KeyValuePair<string, string> pair in asyncFilePaths)
            {
                await asyncStream.FileStreamWriter(pair.Key);
                await asyncStream.FileStreamReader(pair.Key);
                await asyncStream.BufferedStreamReader(pair.Key);
                await asyncStream.ReadProccesAndWriteDataToNewFile(pair.Key, pair.Value);
            }
        }
    }
}