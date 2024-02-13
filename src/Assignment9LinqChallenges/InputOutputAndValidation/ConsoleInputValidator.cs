using System.Runtime.InteropServices;

namespace Assignment9LinqChallenges
{
    /// <summary>
    /// validates the input got from various classes
    /// </summary>
    public class ConsoleInputValidator
    {
        /// <summary>
        /// Checks whether the product quanity integer
        /// </summary>
        /// <param name="idInput">Product quanitity as string</param>
        /// <param name="idOutput">ots product quantity as double</param>
        /// <returns>true if product quantity int else false</returns>
        public bool IsGivenIdPositiveInt(string? idInput, out int idOutput)
        {
            return int.TryParse(idInput, out idOutput) && idOutput > 0;
        }

        /// <summary>
        /// Cheks whether double or not
        /// </summary>
        /// <param name="productPrice">String input</param>
        /// <param name="productPriceOutput">Double output</param>
        /// <returns>true if product price double else false</returns>
        public bool IsProductPricePositiveDouble(string? productPrice, out double productPriceOutput)
        {
            return double.TryParse(productPrice, out productPriceOutput) && productPriceOutput > 0;
        }

        /// <summary>
        /// validates user input if the input is int and lies between 1-5
        /// </summary>
        /// <param name="optionInput">string input form the user</param>
        /// <param name="option">Valid int output</param>
        /// <returns>True if The input is valid</returns>
        public bool IsOptionInputValid(string optionInput, out int option)
        {
            return int.TryParse(optionInput, out option) && (option > 0 && (option < 8));
        }
    }
}
