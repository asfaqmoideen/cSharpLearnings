namespace AdvancedMultiThreading
{
    /// <summary>
    /// Operates the math function in MultiThreading 
    /// </summary>
    public class MultiThreadingOpertaions
    {
        /// <summary>
        /// Runs the function in multi threaded manner
        /// </summary>
        public void MultiThreadingExecutor()
        {
            Thread thread1 = new Thread(sumofInteger => MathCalculations.CalculateSumOfIntegerArray());
            Thread thread2 = new Thread(sumOfRandom => MathCalculations.SortRandomArrayandSum());

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            Console.WriteLine(thread1);
            Console.WriteLine(thread2);
        }
    }
}
