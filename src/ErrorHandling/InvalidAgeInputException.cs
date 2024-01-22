namespace Assignments
{   /// <summary>
    /// Custom exception class
    /// </summary>
    public class InvalidAgeInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAgeInputException"/> class.
        /// Cin
        /// </summary>
        public InvalidAgeInputException()
            : base(string.Format("Invalid Age to Vote"))
        {
        }
    }
}