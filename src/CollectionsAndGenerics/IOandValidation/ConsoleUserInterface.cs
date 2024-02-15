namespace CollectionsAndGenerics
{
    /// <summary>
    /// Get input from the user via console.
    /// </summary>
    public class ConsoleUserInterface
    {
        private ConsoleInputValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleUserInterface"/> class.
        /// </summary>
        public ConsoleUserInterface()
        {
            this._validator = new ConsoleInputValidator();
        }

        /// <summary>
        /// gets user input from user via console
        /// </summary>
        /// <returns>user option as int</returns>
        public static int GetOptionFromUser()
        {
            int option;
            Console.WriteLine("Enter Option to procced");
            ConsoleInputValidator.IsOptionInputValid(Console.ReadLine() !, out option);
            return option;
        }

        /// <summary>
        /// Confirm user to add another details
        /// </summary>
        /// <returns>True if user press 1</returns>
        /// <param name="useCase">usecase of teh Functionality when it is Called</param>
        public static bool UserConfirmation(string useCase)
        {
            Console.WriteLine($"Press Enter to perform {useCase} or Press any key to skip");
            return Console.ReadKey().Key == ConsoleKey.Enter;
        }

        /// <summary>
        /// Gets String Input from user via console and converts to Generic type T
        /// </summary>
        /// <param name="useCase">Usecase while calling this functionality</param>
        /// <returns>The valid string</returns>
        public static string GetStringFromTheUser(string useCase)
        {
            string validString;
            bool isValid;
            Console.WriteLine($"Enter value to {useCase}");
            do
            {
                isValid = ConsoleInputValidator.IsStringValid(Console.ReadLine(), out validString);
            }
            while (!isValid);

            return validString;
        }

        /// <summary>
        /// Gets input from the user
        /// </summary>
        /// <param name="useCase">Use case when the function is called</param>
        /// <returns>valid input value</returns>
        public static int GetIntFromTheUser(string useCase)
        {
            int newIntValue;
            bool isValid;
            Console.WriteLine($"Enter Value to {useCase}");
            do
            {
                isValid = ConsoleInputValidator.IsIntValid(Console.ReadLine(), out newIntValue);
            }
            while (!isValid);
            return newIntValue;
        }
    }
}
