using CSharpConsoleSolution;

namespace CSharpConsoleSolution
{
    /// <summary>
    /// Gets input from the user and prints the result
    /// </summary>
    public class UserOutputConsole
    {
        /// <summary>
        /// Gets operands from the user
        /// </summary>
        /// <returns>opreand value as double</returns>
        /// <param name="useCase">useCase when the function is called</param>
        public static double GetOperands(string useCase)
        {
            Console.WriteLine(useCase);
            return UserInputConsole.GetOperandFromUser();
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
        /// <param name="useCase">Usecase while the function is called</param>
        public static int GetUserOption(string useCase)
        {
            Console.WriteLine(useCase);
            return UserInputConsole.GetOptionFromUser();
        }

        /// <summary>
        /// Prints anything passed to it
        /// </summary>
        /// <param name="v">String value to be printed </param>
        public static void PrintAny(string v)
        {
            Console.WriteLine(v);
        }
    }
}
