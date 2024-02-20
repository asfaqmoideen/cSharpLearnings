
namespace BoilerControllerConsole
{
    /// <summary>
    /// Gets Valid Input from the user 
    /// </summary>
    public class ConsoleUserInterface
    {
        /// <summary>
        /// gets option to perform from the main menu
        /// </summary>
        /// <returns>Integer value </returns>
        public static int GetOptionFromTheUser()
        {
            int userOption;
            Console.WriteLine("Enter a Option to Perform");
            while (!ConsoleInputValidator.IsOptionValid(Console.ReadLine() !, out userOption))
            {
                Console.WriteLine("Enter a Valid Option (0 - 5)");
            }

            return userOption;
        }

        /// <summary>
        /// Gets userconfirmation
        /// </summary>
        /// <param name="useCaseForConfirmation"> Information to get confirmation</param>
        /// <returns>true if yes, else false</returns>
        public static bool GetUserConfirmation(string useCaseForConfirmation)
        {
            Console.WriteLine($"Press Tab to {useCaseForConfirmation}");
            return Console.ReadKey().Key == ConsoleKey.Tab;
        }
    }
}