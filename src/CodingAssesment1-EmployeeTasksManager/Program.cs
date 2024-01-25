using Assignemnts;

namespace Assignments
{
    /// <summary>
    /// Initiates the Program
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Employee Tasks Manager");

                Console.WriteLine("Choose any option to proceed\n1.Manage Employee\n2.ManageTasks\n3.Run Schedule Task");
                string option = Console.ReadLine();
                TasksManager tasksManager = new TasksManager();
                EmployeeManager employeeManager = new EmployeeManager();
                ScheduleTasks scheduleTasks = new ScheduleTasks();
                if (option != null)
                {
                    if (option == "1")
                    {
                        employeeManager.ExecuteEmployeemanager();
                    }
                    else if (option == "2")
                    {
                        tasksManager.ExecuteTasksmanager();
                    }
                    else if (option == "3")
                    {
                        scheduleTasks.StartAllocationgTasks();
                    }
                    else if (option == "4")
                    {
                        scheduleTasks.ShowResults();
                    }
                }
            }
        }
    }
}
