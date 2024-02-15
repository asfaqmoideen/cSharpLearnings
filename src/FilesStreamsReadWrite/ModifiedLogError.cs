using System.Text;

namespace FilesStreamsReadWrite
{
    /// <summary>
    /// Modified log error
    /// </summary>
    public class ModifiedLogError
    {
        private object _lockTheThread = new object();

        /// <summary>
        /// Modfied logger
        /// </summary>
        /// <param name="errorMessage"> Error Message</param>
        /// <param name="userId">user id</param>
        public static void ModifiedLogger(string errorMessage, string userId)
        {
            string logFile = $"log_user{userId}.txt";
            lock (this._lockTheThread)
            {
                using (FileStream filewriter = new FileStream(logFile, FileMode.Append))
                {
                    byte[] data = Encoding.Default.GetBytes(errorMessage);
                    filewriter.Write(data, 0, data.Length);
                }
            }
        }
    }
}
