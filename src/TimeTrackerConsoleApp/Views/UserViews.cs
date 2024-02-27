
namespace TimeTrackerConsoleApp
{
    /// <summary>
    /// User interface for User controls
    /// </summary>
    public class UserViews
    {
        /// <summary>
        /// Get user confirmation to procced with critical user operations
        /// </summary>
        /// <param name="useCaseToGetConfirmation">Interpoled String </param>
        /// <returns>true if user press tab</returns>
        public static bool GetConfirmation(string useCaseToGetConfirmation)
        {
            Console.WriteLine($"Press Tab to Confirm {useCaseToGetConfirmation}");
            return Console.ReadKey().Key == ConsoleKey.Tab;
        }

        /// <summary>
        /// Gets string from user
        /// </summary>
        /// <param name="useCase">Usecase to get string</param>
        /// <returns>string</returns>
        public static string GetStringFromUser(string useCase)
        {
            Console.WriteLine(useCase);
            return Console.ReadLine() !;
        }

        internal static int GetOptionFromTheUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints the message to the user
        /// </summary>
        /// <param name="stringToDisplayed">stringToDisplayed</param>
        internal static void PrintMessage(string stringToDisplayed)
        {
            Console.WriteLine(stringToDisplayed);
        }
    }
}