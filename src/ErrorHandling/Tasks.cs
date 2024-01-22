using System.Formats.Asn1;

namespace Assignments
{
    /// <summary>
    /// Class with all the tasks
    /// </summary>
    public partial class Tasks
    {
        /// <summary>
        /// Try catch method to throw exception called divideby zero exception
        /// </summary>
        public void TryCatchFinallyDivideByZeroExeption()
        {
            Console.WriteLine("Task 1 - Divide By Zero Exception");
            Console.WriteLine("Enter a Divident");
            int divident = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Divisor");
            int divisor = int.Parse(Console.ReadLine());
            try
            {
                decimal result = divident / divisor;
            }
            catch (DivideByZeroException e1)
            {
                Console.WriteLine(e1.Message);
            }
            finally
            {
                Console.WriteLine("Task 1 Executed\n");
            }
        }

        /// <summary>
        /// Try catch finally block to catch the exception thrown from the inner function call without catch exception
        /// </summary>
        public void TryCatchIndexOutsideBoundary()
        {
            Console.WriteLine("Task 2 Index Outside Boundary Exception");
            try
            {
                TryCatchIndexOutsideBoundary1();
            }
            catch (IndexOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            finally
            {
                Console.WriteLine("Task 2  Executed\n");
            }
        } 
        /// <summary>
        /// Just throws an Exception will be catch by enclosing scope of function
        /// </summary>
        public void TryCatchIndexOutsideBoundary1()
        {
            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (IndexOutOfRangeException e2)
            {
                throw new IndexOutOfRangeException("The given index is outside the boundary");
            }
        }
        /// <summary>
        /// Method to try catch with custom Exception InvalidAgeInputException
        /// </summary>
        public void InvalidUserInputException()
        {
            Console.WriteLine("Task 3 Invalid User Input With Custom Exception Class");
            try
            {
                // uint ageToVote = uint.Parse(Console.ReadLine());
                uint ageToVote = 2;
                if (ageToVote < 18 )
                {
                    throw new InvalidAgeInputException();
                }
            }
            catch (InvalidAgeInputException e3)
            {
                Console.WriteLine(e3.Message);
            }
            finally
            {
                Console.WriteLine("Task 3 Executed \n");
            }
        }
        /// <summary>
        /// A New Exception to Throw, and catch by AppDomain Unhandled Excetion Handler with StackTrace
        /// </summary>
        public void KeyNotFoundException()
        {  
            Console.WriteLine("Task 4,5 - KeyNotFoundException");
            Dictionary<int, string> keys = new Dictionary<int, string>();

            keys.Add(1, "five");
            try
            {
                Console.WriteLine(keys[2]);
                throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException e3)
            {
                throw e3;
            }
            finally
            {
                Console.WriteLine("Unhandled Exception Handled Executed\n");
            }
        }
    }
}