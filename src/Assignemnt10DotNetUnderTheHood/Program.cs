﻿using System.ComponentModel;

namespace Assignemnt10DotNetUnderTheHood
{
    /// <summary>
    /// Initiates the program execution
    /// </summary>
    internal class Program
    {
        private enum Option
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide,
            Exit
        }

        /// <summary>
        /// The initialization of the program
        /// </summary>
        private static void Main()
        {
            MathUtils mathUtils = new MathUtils();
            bool stop = false;
            do
            {
                try
                {
                    Console.WriteLine("\t.NET Under The Hood\nSimple Calculator");

                    Console.WriteLine("Enter First Number : ");

                    double operandOne = GetOperandFromUser();

                    Console.WriteLine("Enter Second Number : ");

                    double operandTwo = GetOperandFromUser();

                    Console.WriteLine("Choose any Operation to Execute\n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Exit");

                    bool isOptionValid = false;
                    int option;
                    string optionstring = Console.ReadLine();
                    isOptionValid = int.TryParse(optionstring, out option) && (0 < option && option < 5);
                    while (!isOptionValid)
                    {
                        Console.WriteLine("Invalid Option");
                        isOptionValid = int.TryParse(Console.ReadLine(), out option) && (0 < option && (option < 5));
                    }

                    Option useroption = (Option)option;
                    switch (useroption)
                    {
                        case Option.Add:
                            double additionAnswer = mathUtils.Addition(operandOne, operandTwo);
                            PrintResult(additionAnswer);
                            break;
                        case Option.Subtract:
                            double subtractAnswer = mathUtils.Subtract(operandTwo, operandOne);
                            PrintResult(subtractAnswer);
                            break;
                        case Option.Multiply:
                            double multiplyAnswer = mathUtils.Multiplication(operandOne, operandOne);
                            PrintResult(multiplyAnswer);
                            break;
                        case Option.Divide:
                            double divisionAnswer = mathUtils.Divide(operandOne, operandTwo);
                            PrintResult(divisionAnswer);
                            break;
                        case Option.Exit:
                            stop = true;
                            break;
                        default:
                            break;
                    }

                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (stop);
        }

        private static double GetOperandFromUser()
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                throw new Exception();
            }
            bool isNumberValid = false;
            double operand;
            string operandString = Console.ReadLine();
            isNumberValid = double.TryParse(operandString, out operand);
            while (!isNumberValid)
            {
                Console.WriteLine("Invalid Operand");
                isNumberValid = double.TryParse(Console.ReadLine(), out operand);
            }
            return operand;
        }

        private static void PrintResult(double result)
        {
            Console.WriteLine("The Result is " + result);
        }
    }
}