using Reflections;

namespace Assignments
{
    /// <summary>
    /// Initiates the Program Execution
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the Program
        /// </summary>
        private static void Main()
        {
            Student student = new Student ();
            DynamicObjectInspector dynamicObjectInspector = new ();
            dynamicObjectInspector.GetTypeof(student);

            InspectAssembly assembly = new InspectAssembly();
            assembly.ExecuteAssemblyInspector();

            Console.WriteLine("Program Completed!");
            Console.ReadKey();
        }
    }
}