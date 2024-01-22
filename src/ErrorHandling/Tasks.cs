namespace Assignments
{
    /// <summary>
    /// Class with all the tasks
    /// </summary>
    public partial class Tasks
    {
        /// <summary>
        /// dsf
        /// </summary>
        public void TryCatchFinallyDivideByZeroExeption()
        {
            Console.WriteLine("Divide By Zero Exception");
            Console.WriteLine("Enter a Divident");
            int divident = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Divider");
            int divider = int.Parse(Console.ReadLine());
            try
            {
                decimal result = divident / divider;
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (DivideByZeroException e1)
            {
               Console.WriteLine(e1.Message);
            }
            catch (IndexOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            finally
            {
                Console.WriteLine("Block Executed\n");
            }
        }
        /// <summary>
        /// Try catch finally block to catch the outside boundary exception
        /// </summary>
        public void TryCatchIndexOutsideBoundary()
        {
            Console.WriteLine("Index Outside Boundary Exception");
            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (IndexOutOfRangeException e2)
            {
                Console.WriteLine(e2.Message);
            }
            finally
            {
                Console.WriteLine("Block Executed\n");
            }
        }
        /// <summary>
        /// Method to try catch InvalidUserInputException
        /// </summary>
        public void InvalidUserInputException()
        {
            try
            {
                uint ageToVote = uint.Parse(Console.ReadLine());
                if (ageToVote < 18 )
                {
                    throw new InvalidAgeInputException();
                }
            }
            catch (InvalidAgeInputException e2)
            {
                Console.WriteLine(e2.Message);
            }
            finally
            {
                Console.WriteLine("Block Executed\n");
            }
        }
    }
}