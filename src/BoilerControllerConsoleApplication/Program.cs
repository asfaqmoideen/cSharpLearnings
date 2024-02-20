using System.Net.Http.Headers;

namespace BoilerControllerConsole
{
    /// <summary>
    /// Initiates the Program Execution
    /// </summary>
    public class Program
    {
         /// <summary>
         /// Entfry point of the Program
         /// </summary>
        private static void Main()
        {
            bool stopFlag = false;
            MainMenuOperationsManager operationsManager = new();

            while (!stopFlag)
            {
                try
                {
                    stopFlag = operationsManager.ExecuteMainMenu();
                }
                catch (Exception globalException)
                {
                    Console.WriteLine(globalException.Message);
                }
            }
        }
    }
}