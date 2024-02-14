namespace CollectionsAndGenerics
{
    /// <summary>
    /// Get input from the user via console.
    /// </summary>
    public class ConsoleUserInterface
    {
        /// <summary>
        /// gets user input from user via console
        /// </summary>
        /// <returns>user option as int</returns>
        /// <param name="menuOptionsToBePrinted">Menu Options to be Prited in the Console</param>
        public static int PrintMenuDetailsAndGetOptionFromUser(string menuOptionsToBePrinted)
        {
            Console.WriteLine(menuOptionsToBePrinted);
            int option;
            while (!ConsoleInputValidator.IsOptionInputValid(Console.ReadLine() !, out option))
            {
                Console.WriteLine("Invalid Option");
            }

            return option;
        }
    }
}
