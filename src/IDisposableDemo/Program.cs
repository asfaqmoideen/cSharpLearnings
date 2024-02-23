namespace IDisposableDemo
{
    /// <summary>
    /// Initiate the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Initiates the Program Execution with calling Stream Reader and Stream Writer
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("IDisposable Interface");

            using (FileWriter fileWriter = new FileWriter("sample.txt"))
            {
                fileWriter.ExcuteFileWriter("Hello, Asfaq !");
            }

            using (FileReader fileReader = new FileReader("sample.txt"))
            {
                fileReader.ExecuteFileReader();
            }

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }
    }
}