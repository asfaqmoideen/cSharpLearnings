namespace IDisposableDemo
{
    /// <summary>
    /// Reads the file
    /// </summary>
    public class FileReader : IDisposable
    {
        private readonly StreamReader _streamReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// Craet
        /// </summary>
        /// <param name="filepath">file path of the document</param>
        public FileReader(string filepath)
        {
            this._streamReader = new StreamReader(filepath);
        }

        /// <summary>
        /// proceeds to read theline
        /// </summary>
        public void ExecuteFileReader()
        {
            string readvalue = this._streamReader.ReadLine();
            Console.WriteLine(readvalue);
        }

        /// <summary>
        /// Disposes the 
        /// </summary>
        public void Dispose()
        {
            this._streamReader.Dispose();
        }
    }
}
