using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt10DotNetUnderTheHood
{
    /// <summary>
    /// Maths Utils Class to operate the user given operands
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Adds two operands provided valid input
        /// </summary>
        /// <param name="operandOne">operand one</param>
        /// <param name="operandTwo">operand two</param>
        /// <returns>result</returns>
        internal double Addition(double operandOne, double operandTwo)
        {
            return operandOne + operandTwo;
        }

        /// <summary>
        /// Divides two operand throws dividebyZeroException when second oprand is zero
        /// </summary>
        /// <param name="operandOne">operand one</param>
        /// <param name="operandTwo">operand two</param>
        /// <returns>result</returns>
        internal double Divide(double operandOne, double operandTwo)
        {
            return operandOne / operandTwo;
        }

        /// <summary>
        /// Multiplies the two operand
        /// </summary>
        /// <param name="operandOne1">operand one</param>
        /// <param name="operandOne2">operand two</param>
        /// <returns>result</returns>
        internal double Multiplication(double operandOne1, double operandOne2)
        {
            return operandOne1 * operandOne2;
        }

        /// <summary>
        /// differece of two numbers
        /// </summary>
        /// <param name="operandTwo">operand one</param>
        /// <param name="operandOne">o[erand two </param>
        /// <returns>result</returns>
        internal double Subtract(double operandTwo, double operandOne)
        {
            return operandOne - operandTwo;
        }
    }
}
