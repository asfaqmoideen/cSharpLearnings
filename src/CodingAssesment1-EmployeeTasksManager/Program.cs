
namespace Assignments
{
    /// <summary>
    /// Initiates the Program
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to Employee Tasks Manager");

            Console.WriteLine("Choose any option to proceed\n1.Manage Employee\n2.ManageTasks\n3.View Reports");
            string option = Console.ReadLine();
            ExecuteTheOperation(option);
        }

        private static void ExecuteTheOperation(string? option)
        {
            switch (option)
            {
                case "1"


            }
        }
    }
}