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
            return int.TryParse(optionInput, out option);
        }
    }
}
