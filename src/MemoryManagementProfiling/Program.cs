using MemoryManagementProfiling;

namespace Assignments
{
    /// <summary>
    /// Initiates the Program Execution
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starting point of the program
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Memory Management Profiling");

            MemoryEater memoryEater = new MemoryEater();

            memoryEater.Allocate();
        }
    }
}