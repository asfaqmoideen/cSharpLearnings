namespace Assignments
{
    /// <summary>
    /// Initiates the Program
    /// </summary>
    internal class Program
    {
        private TasksManager _tasksManager = new TasksManager();
        private EmployeeManager _employeeManager = new EmployeeManager();
        private static void Main()
        {
            Console.WriteLine("Welcome to Employee Tasks Manager");

            Console.WriteLine("Choose any option to proceed\n1.Manage Employee\n2.ManageTasks\n3.View Reports");
            string option = Console.ReadLine();

            if (option != null)
            {
                if (option == "1")
                {
                    _tasksManager.ExecuteEmployeemanager();
                }
                else if (option == "2")
                {
                    _tasksManger.ExecuteTasksmanger();
                }
            }
        }
    }
}
