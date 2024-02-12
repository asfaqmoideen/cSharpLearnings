namespace CSharpConsoleSolution
{
    /// <summary>
    /// Gets input from the user and prints the result
    /// </summary>
    public class UserIOConsole
    {
        /// <summary>
        /// Gets operands from the user
        /// </summary>
        /// <returns>opreand value as double</returns>
        public static double GetOperandFromUser()
        {
            double operand;
            while (!UserInputValidator.IsOperandValid(Console.ReadLine() !, out operand))
            {
                Console.WriteLine("Invalid Operand");
            }

            return operand;
        }

        /// <summary>
        /// prints the result whenever it is called.
        /// </summary>
        /// <param name="result"> result value </param>
        public static void PrintResult(double result)
        {
            Console.WriteLine("The Result is " + result);
        }

        /// <summary>
        /// Gets user input to execute operaton
        /// </summary>
        /// <returns>User option as int</returns>
        public static int GetUserOption()
        {
            int option;
            while (!UserInputValidator.IsOptionInputValid(Console.ReadLine() !, out option))
            {
                Console.WriteLine("Invalid Option");
            }

            return option;
        }
    }
}
