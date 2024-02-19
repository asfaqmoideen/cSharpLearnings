namespace EventsAndDelegates
{
    /// <summary>
    /// Initiates the program Execution
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry Point of the project
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Events and Delegates");
            Notifier notifier = new ();
            notifier.OnAction -= notifier.MessageNotifier;
            notifier.OnAction += notifier.EmailNotifier;
            notifier.PerformEvent("This is the message to be printed in the console");

            VarAndDynamic dynamic = new ();
            dynamic.CreateVarAndDynamic();

            SortArray sortArray = new SortArray();
            sortArray.SortArrayDelegate(new int[] { 54, 67, 12, 34, 80 });

            LambdaExpressions lambdaExpressions = new LambdaExpressions();
            lambdaExpressions.GenerateList(15);

            Console.ReadKey();
        }
    }
}