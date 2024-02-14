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
            SynchronousStreamProccessor syncStream = new ();
            AsynchronousStreamProcessor asyncStream = new ();
            Console.WriteLine("File Stream Manager");
            try
            {
                syncStream.FileStreamWriter(@"C:\FileStreams\newlyWrittenFile.txt");
                syncStream.FileStreamReader(@"C:\FileStreams\newlyWrittenFile.txt");
                syncStream.BufferedStreamReader(@"C:\FileStreams\newlyWrittenFile.txt");
                syncStream.ReadProccesAndWriteDataToNewFile(@"C:\FileStreams\newlyWrittenFile.txt", @"C:\FileStreams\processedData.txt");

                await asyncStream.FileStreamWriter(@"C:\FileStreams\asyncnewlyWrittenFile.txt");
                await asyncStream.FileStreamReader(@"C:\FileStreams\asyncnewlyWrittenFile.txt");
                await asyncStream.BufferedStreamReader(@"C:\FileStreams\asyncnewlyWrittenFile.txt");
                await asyncStream.ReadProccesAndWriteDataToNewFile(@"C:\FileStreams\asyncnewlyWrittenFile.txt", @"C:\FileStreams\asyncprocessesData.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}