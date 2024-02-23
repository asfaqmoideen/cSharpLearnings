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
        /// Executes the StreamReader method defined in Streamrider
        /// </summary>
        public void ExecuteFileReader()
        {
            string readvalue = this._streamReader.ReadLine();
            Console.WriteLine(readvalue);
        }

        /// <summary>
        /// Execuets the dispose method defined in IDisposable Method
        /// </summary>
        public void Dispose()
        {
            this._streamReader.Dispose();
        }
    }
}
