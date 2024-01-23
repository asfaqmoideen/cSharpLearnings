namespace Assignments
{
    /// <summary>
    /// Inaites the program execution
    /// </summary>
    internal partial class Program
    {
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            try
            {
                Tasks tasks = new Tasks();
                tasks.TryCatchFinallyDivideByZeroExeption();
                tasks.TryCatchIndexOutsideBoundary();
                tasks.InvalidUserInputException();
                tasks.KeyNotFoundException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Task 5 ");
                Console.WriteLine("The StackTrace is :" + ex.StackTrace);
                Console.ReadKey();
            }
        }

        private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Unhandled Exception: "+ e.Message);
            Console.WriteLine("RunTime Terminating: "+ args.IsTerminating );
        }
    }
} 