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
                    Console.WriteLine("\tSimple Calculator");

                    double operandOne, operandTwo;
                    GetOperandsFromTheUser(out operandOne, out operandTwo);

                    Console.WriteLine("Choose any Operation to Execute\n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Exit");

                    int option = UserIOConsole.GetUserOption();

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
            Console.WriteLine("Enter First Number : ");
            operandOne = UserIOConsole.GetOperandFromUser();

            Console.WriteLine("Enter Second Number : ");
            operandTwo = UserIOConsole.GetOperandFromUser();
        }

        private static bool ExecuteUserOperation(MathUtils mathUtils, bool stop, double operandOne, double operandTwo, Option useroption)
        {
            switch (useroption)
            {
                case Option.Add:
                    double additionAnswer = mathUtils.Addition(operandOne, operandTwo);
                    UserIOConsole.PrintResult(additionAnswer);
                    break;
                case Option.Subtract:
                    double subtractAnswer = mathUtils.Subtract(operandTwo, operandOne);
                    UserIOConsole.PrintResult(subtractAnswer);
                    break;
                case Option.Multiply:
                    double multiplyAnswer = mathUtils.Multiplication(operandOne, operandOne);
                    UserIOConsole.PrintResult(multiplyAnswer);
                    break;
                case Option.Divide:
                    double divisionAnswer = mathUtils.Divide(operandOne, operandTwo);
                    UserIOConsole.PrintResult(divisionAnswer);
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