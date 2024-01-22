namespace Assignments
{
    /// <summary>
    /// Inaites the program execution
    /// </summary>
    internal partial class Program
    {
        private static void Main()
        {
            while (true)
            {
                Tasks tasks = new Tasks();
                Console.WriteLine("Hello");
                tasks.TryCatchFinallyDivideByZeroExeption();
                tasks.TryCatchIndexOutsideBoundary();
                tasks.InvalidUserInputException();
            }
        }
    }
}