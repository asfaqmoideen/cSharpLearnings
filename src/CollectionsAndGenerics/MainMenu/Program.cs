using CollectionsAndGenerics;

namespace Assignments
{
    /// <summary>
    /// Initiates the program execution
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starting point of the program
        /// </summary>
        public static void Main()
        {
            bool stop = false;

            MainMenuExecutionManager manager = new MainMenuExecutionManager();
            do
            {
                try
                {
                    manager.MainMenu(out stop);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!stop);
        }
    }
}