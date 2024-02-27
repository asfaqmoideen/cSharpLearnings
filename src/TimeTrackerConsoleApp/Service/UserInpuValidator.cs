namespace TimeTrackerConsoleApp
{
    /// <summary>
    /// Validates the user input
    /// </summary>
    public class UserInpuValidator
    {
        /// <summary>
        /// Checks whether the string empty or contains digit
        /// </summary>
        /// <param name="stringToValidate">string to valid</param>
        /// <returns>True if valid</returns>
        public static bool IsStringValid(string stringToValidate)
        {
            return string.IsNullOrEmpty(stringToValidate) && stringToValidate.Any(char.IsDigit);
        }
    }
}