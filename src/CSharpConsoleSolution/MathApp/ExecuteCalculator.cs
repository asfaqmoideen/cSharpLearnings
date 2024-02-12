namespace CSharpConsoleSolution
{
    /// <summary>
    /// Execute the calculator operation
    /// </summary>
    public class ExecuteCalculator
    {
        private static MathUtils _mathUtils = new MathUtils();

        private enum Option
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide,
            Exit,
        }

        /// <summary>
        /// The initialization of the program
        /// </summary>
        public static void ExecuteMathOperation()
        {
            bool stop = true;
            do
            {
                try
                {
                    UserOutputConsole.PrintAny("Simple Calculator");

                    double operandOne, operandTwo;
                    GetOperandsFromTheUser(out operandOne, out operandTwo);

                    int option = UserOutputConsole.GetUserOption("Choose any Operation to Execute\n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Exit");

                    Option useroption = (Option)option;
                    stop = ExecuteUserOperation(_mathUtils, stop, operandOne, operandTwo, useroption);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (stop);
        }

        private static void GetOperandsFromTheUser(out double operandOne, out double operandTwo)
        {
            operandOne = UserOutputConsole.GetOperands("Enter First Number : ");

            operandTwo = UserOutputConsole.GetOperands("Enter Second Number : ");
        }

        private static bool ExecuteUserOperation(MathUtils mathUtils, bool stop, double operandOne, double operandTwo, Option useroption)
        {
            switch (useroption)
            {
                case Option.Add:
                    double additionAnswer = mathUtils.Addition(operandOne, operandTwo);
                    UserOutputConsole.PrintResult(additionAnswer);
                    break;
                case Option.Subtract:
                    double subtractAnswer = mathUtils.Subtract(operandTwo, operandOne);
                    UserOutputConsole.PrintResult(subtractAnswer);
                    break;
                case Option.Multiply:
                    double multiplyAnswer = mathUtils.Multiplication(operandOne, operandOne);
                    UserOutputConsole.PrintResult(multiplyAnswer);
                    break;
                case Option.Divide:
                    double divisionAnswer = mathUtils.Divide(operandOne, operandTwo);
                    UserOutputConsole.PrintResult(divisionAnswer);
                    break;
                case Option.Exit:
                    stop = false;
                    break;
                default:
                    break;
            }

            return stop;
        }
    }
}