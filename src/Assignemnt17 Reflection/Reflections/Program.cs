using Reflections;

namespace Assignments
{
    /// <summary>
    /// Initiates the Program Execution
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the Program
        /// </summary>
        private static void Main()
        {
            bool stopFlag = false;

            while (!stopFlag)
            {
                MainMenuExecutionManager mainMenuExecutionManager = new();
                Console.WriteLine("Reflection in C#");
                try
                {
                    stopFlag = mainMenuExecutionManager.ExecuteMainMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}