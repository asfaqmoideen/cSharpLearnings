namespace IDisposableDemo
{
    /// <summary>
    /// Creates and writes value in files
    /// </summary>
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filepath">File path of the file</param>
        public FileWriter(string filepath)
        {
            this._streamWriter = new StreamWriter(filepath, true);
        }

        /// <summary>
        /// Execute the file writter method written in StreamWriter Class
        /// </summary>
        /// <param name="text">The text to be written in the File</param>
        public void ExcuteFileWriter(string text)
        {
            this._streamWriter.WriteLine(text);
            this._streamWriter.Flush();
        }

        /// <summary>
        /// Dispose Method to execute Dispose Method defined in IDisposable
        /// </summary>
        public void Dispose()
        {
            this._streamWriter.Dispose();
        }
    }
}
