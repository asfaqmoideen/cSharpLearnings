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

        /// <summary>
        /// Confirm user to add another details
        /// </summary>
        /// <returns>True if user press 1</returns>
        /// <param name="useCase">usecase of teh Functionality when it is Called</param>
        public static bool IsAddAnotherDetail(string useCase)
        {
            Console.WriteLine($"Add Another {useCase} ?\n1.Yes\nPress any key to skip");
            string? addAnother = Console.ReadLine();
            return addAnother == "1";
        }

        /// <summary>
        /// Gets String Input from user via console and converts to Generic type T
        /// </summary>
        /// <param name="useCase">Usecase while calling this functionality</param>
        /// <returns>generic Type T of the string</returns>
        /// <typeparam name="T">Generic method type</typeparam>
        public static T GetAndConvertStringToType<T>(string useCase)
        {
            Console.WriteLine($"Enter value to {useCase}");
            string? inputString = Console.ReadLine();

            while (!ConsoleInputValidator.IsGivenIputIsNotNull(inputString))
            {
                Console.WriteLine("Enter a Non null value");
                inputString = Console.ReadLine();
            }

            return (T)Convert.ChangeType(inputString, typeof(T));
        }
    }
}
