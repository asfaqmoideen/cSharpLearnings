using FilesStreamsReadWrite;

namespace Assignments
{
    /// <summary>
    /// Initiates the program execution
    /// </summary>
    internal class Program
    {
        private static FileStreamManager streamManager = new ();

        /// <summary>
        /// Entry point of the program
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("File Stream Manager");
            try
            {
                streamManager.FileStreamWriter();
                streamManager.FileStreamReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}