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
        /// <param name="filepath">takes file path</param>
        public FileWriter(string filepath)
        {
            this._streamWriter = new StreamWriter(filepath, true);
        }

        /// <summary>
        /// Execute the file writter
        /// </summary>
        /// <param name="text">text to be written</param>
        public void ExcuteFileWriter(string text)
        {
            this._streamWriter.WriteLine(text);
            this._streamWriter.Flush();
        }

        /// <summary>
        /// Dispose Method
        /// </summary>
        public void Dispose()
        {
            this._streamWriter.Dispose();
        }
    }
}
