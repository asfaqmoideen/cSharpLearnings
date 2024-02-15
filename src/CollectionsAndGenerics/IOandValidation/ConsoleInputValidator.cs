namespace CollectionsAndGenerics
{
    /// <summary>
    /// Validates the input given via console
    /// </summary>
    public class ConsoleInputValidator
    {
        /// <summary>
        /// validates user input if the input is int
        /// </summary>
        /// <param name="optionInput">string input form the user</param>
        /// <param name="option">Valid int output</param>
        /// <returns>True if The input is valid</returns>
        public static bool IsOptionInputValid(string optionInput, out int option)
        {
            if (string.IsNullOrEmpty(optionInput))
            {
                throw new Exception("Option sould not be empty");
            }
            else if (!int.TryParse(optionInput, out option))
            {
                throw new Exception("Should be a Number");
            }

            return true;
        }

        /// <summary>
        /// Checks whether the give input is not null
        /// </summary>
        /// <param name="consoleInputValue">Got from console readline</param>
        /// <param name="outputValue">not null out put value</param>
        /// <returns>True if the Inout is not null</returns>
        public static bool IsStringValid(string? consoleInputValue, out string outputValue)
        {
            outputValue = consoleInputValue ?? string.Empty;
            return !string.IsNullOrEmpty(consoleInputValue);
        }

        /// <summary>
        /// Validates the string
        /// </summary>
        /// <param name="intInput">input value as string</param>
        /// <param name="validIntValue">valid input</param>
        /// <returns>true if valid int</returns>
        public static bool IsIntValid(string? intInput, out int validIntValue)
        {
            if (string.IsNullOrEmpty(intInput))
            {
                throw new Exception("Option sould not be empty");
            }
            else if (!int.TryParse(intInput, out validIntValue))
            {
                throw new Exception("Not a Number");
            }

            return true;
        }
    }
}
