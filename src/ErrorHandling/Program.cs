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
            while (true)
            {
                Tasks tasks = new Tasks();
                Console.WriteLine("Hello");
                tasks.TryCatchFinallyDivideByZeroExeption();
                tasks.TryCatchIndexOutsideBoundary();
                tasks.InvalidUserInputException();
                tasks.KeyNotFoundException();
            }
        }

        private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Unhandled Exception: "+ e.Message);
            Console.WriteLine("RunTime Terminating: "+ args.IsTerminating );
            Console.WriteLine("The StackTrace is :" +e.StackTrace);
            Console.ReadKey();
        }
    }
} 