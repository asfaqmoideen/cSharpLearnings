using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace FilesStreamsReadWrite
{
    /// <summary>
    /// Handle File Stream read write and performance analysis
    /// </summary>
    public class FileStreamManager
    {
        private string _path = "newlyWrittenFile.txt";

        /// <summary>
        /// Writes into the files
        /// </summary>
        public void FileStreamWriter()
        {
            string data = "This is some test data";

            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                using (FileStream fileStream = new FileStream(this._path, FileMode.OpenOrCreate))
                {
                    while (new System.IO.FileInfo("newlyWrittenFile.txt").Length < 1073741824)
                    {
                        byte[] writeBuffer = memoryStream.ToArray();
                        fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Read From the file
        /// </summary>
        public void FileStreamReader()
        {
            using (FileStream fileStream = new FileStream(this._path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //sjdsalka
                }

                stopwatch.Stop();
                var ts = stopwatch.Elapsed;
                Console.WriteLine(ts.Milliseconds);
            }
        }
    }
}
