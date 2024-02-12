namespace CSharpConsoleSolution
{
    /// <summary>
    /// Validates the user input
    /// </summary>
    public class UserInputValidator
    {
        /// <summary>
        /// validates user input if the input is int and lies between 1-5
        /// </summary>
        /// <param name="optionInput">string input form the user</param>
        /// <param name="option">Valid int output</param>
        /// <returns>True if The input is valid</returns>
        public static bool IsOptionInputValid(string optionInput, out int option)
        {
            return int.TryParse(optionInput, out option) && (option > 0 && (option < 6));
        }

        /// <summary>
        /// Validates the operand input
        /// </summary>
        /// <param name="operandInput">Operand input as string</param>
        /// <param name="operand">double operand value</param>
        /// <returns>true if the operand is valid</returns>
        public static bool IsOperandValid(string operandInput, out double operand)
        {
            return double.TryParse(operandInput, out operand) && operandInput.Length != 0;
        }
    }
}
