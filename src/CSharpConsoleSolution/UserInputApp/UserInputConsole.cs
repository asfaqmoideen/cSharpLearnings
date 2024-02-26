namespace CSharpConsoleSolution
{
    /// <summary>
    /// Gets user input through console
    /// </summary>
    public class UserInputConsole
    {
        /// <summary>
        /// Gets operand form the user
        /// </summary>
        /// <returns>operand value as double</returns>
        public static double GetOperandFromUser()
        {
            double operand;
            while (!UserInputValidator.IsOperandValid(Console.ReadLine()!, out operand))
            {
                Console.WriteLine("Invalid Operand");
            }

            return operand;
        }

        /// <summary>
        /// gets user input from user via console
        /// </summary>
        /// <returns>user option as int</returns>
        public static int GetOptionFromUser()
        {
            int option;
            while (!UserInputValidator.IsOptionInputValid(Console.ReadLine()!, out option))
            {
                Console.WriteLine("Invalid Option");
            }

            return option;
        }
    }
}
